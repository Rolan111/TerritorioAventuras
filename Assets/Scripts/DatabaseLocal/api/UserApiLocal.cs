using UnityEngine;


public class UserApiLocal : MonoBehaviour
{
    
    private void Start()
    {
        UserModel user = DbConnectionLocal.Read<UserModel>("SELECT * FROM user WHERE user='Juan' and password='Juan' ");
        if(user == null)
        {
            Debug.Log("FALLO EL LOGIN PARA EL USUARIO");
        }
        else
        {
            Debug.Log("LOGIN CORRECTO PARA EL USUARIO");
        }
    }
}
