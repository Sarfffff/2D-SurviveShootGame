using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 6f;
    private Rigidbody rb;
    private Animator anim;
    //private CharacterController player;
    private void Awake()
    {
       rb = GetComponent<Rigidbody>();
       anim = GetComponent<Animator>();
       //player = GetComponent<CharacterController>();
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");   //水平轴
        float y = Input.GetAxisRaw("Vertical");     //垂直轴

        Move(x, y);
        Turning();
        Animting(x, y);
        // Movement = transform.TransformDirection(Movement);
        // transform.Translate(Movement);


    }
    void Move(float h,float v)
    {//在同时按下两个移动键是将速度置为最基础的速度
        Vector3 Movement = new Vector3(h, 0, v);
        Movement = Movement.normalized * MoveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + Movement);
    }
    void Turning()
    {
        //创建相机（鼠标位置)
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);//从主相机向鼠标所在屏幕位置发射一条射线。
        int floorLayer = LayerMask.GetMask("floor");//获取floor的图层掩码，用于射线检测时在检测该图层的物体
        RaycastHit floorHit;
        //射线检测
       bool isTouchfloor = Physics.Raycast(cameraRay,out floorHit, 100,floorLayer);
        //进行射线检测，检查射线是否击中了 "Floor" 图层的物体，检测距离为 100 个单位
       
        
        if (isTouchfloor) {//射线是否击中floor
            Vector3 v3 = floorHit.point - transform.position;
            v3.y = 0;        
            Quaternion quaternion = Quaternion.LookRotation(v3);
                // 使用刚体的 MoveRotation 方法设置旋转
            rb.MoveRotation(quaternion);
            
        }
    }
    void Animting(float h, float v)
    {
        bool isMove = false;
        if (h != 0 || v != 0)
            isMove = true;
        anim.SetBool("Move", isMove);
    }
}
