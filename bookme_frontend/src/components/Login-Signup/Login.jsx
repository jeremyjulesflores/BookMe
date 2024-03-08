import { useState } from 'react';
import { loginFields } from "../../constants";
import FormAction from "./FormAction";
import FormExtra from "./FormExtra";
import Input from "./Input";
import {useNavigate} from 'react-router-dom'
import axios from 'axios'

const fields=loginFields;
let fieldsState = {};
fields.forEach(field=>fieldsState[field.id]='');

export default function Login(){
    const [loginState,setLoginState]=useState(fieldsState);
    const [loginSuccess, setLoginSuccess] = useState(false);
    const [loginFail, setLoginFail] = useState(false);
    const navigate = useNavigate();

    const handleChange=(e)=>{
        const { id, value } = e.target;
        setLoginState({...loginState,[id]:value})
    }

    const handleSubmit=(e)=>{
        e.preventDefault();
        authenticateUser();
    }

    //Handle Login API Integration here
    const authenticateUser = async() =>{
        try{
            console.log({
                Email : loginState.emailaddress,
                Password : loginState.password
            })
            await axios.post('https://localhost:44311/api/Auth', {
                Email: loginState.emailaddress,
                Password: loginState.password
            },
            {
                headers:{
                    'Content-Type' : 'application/json'
                }
            }).then (response =>{
                if (response.status == 200){
                    const token = response.data;
                    setLoginSuccess(true);
                    navigate('/login-success');
                    console.log("Success");
                    
                }else{
                    setLoginFail(true);
                    console.log("Fail");
                    console.log(response);
                }
            })
        
                
        

        }catch(error){
            console.error('Error Logging in', error);
        }
    }

    return(
        <form className="mt-8 space-y-6" onSubmit={handleSubmit}>
        <div className="-space-y-px">
            {
                fields.map(field=>
                        <Input
                            key={field.id}
                            handleChange={handleChange}
                            value={loginState[field.id]}
                            labelText={field.labelText}
                            labelFor={field.labelFor}
                            id={field.id}
                            name={field.name}
                            type={field.type}
                            isRequired={field.isRequired}
                            placeholder={field.placeholder}
                    />
                
                )
            }
        </div>

        <FormExtra/>
        <FormAction handleSubmit={handleSubmit} text="Login"/>

      </form>
    )
}