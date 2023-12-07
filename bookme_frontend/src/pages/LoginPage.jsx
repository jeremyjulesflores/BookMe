import Header from "../components/Login-Signup/Header"
import Login from "../components/Login-Signup/Login"
import styles from "../style"
import { sample01 } from "../assets"
import Button from "../components/Button"

export default function LoginPage(){
    return(
        <div className={`${styles.paddingX} ${styles.flexCenter}`}>
            <div className={`${styles.boxWidth}`}>
                <div className= {`flex md:flex-row flex-col ${styles.paddingY}`}>
                        <div>
                            {/* Back Button */}
                            <Button styles={`mt-10 bg-transparent`} text ={'Back'} link={'/'}/>
                        </div>
                    <div className={`flex-1 flex-col ${styles.flexCenter} md:my-0  my-10 relative`}>
                        
                       
                        <img src={sample01} alt="sample" className="  w-[50%] h-[100%] relative z-[5] md:w-[100%]" />
                        
                        {/* gradient start */}
                        <div className="absolute z-[0] w-[40%] h-[35%] top-0 pink__gradient" />
                        <div className="absolute z-[1] w-[80%] h-[80%] rounded-full white__gradient bottom-40" />
                        <div className="absolute z-[0] w-[50%] h-[50%] right-20 bottom-20 blue__gradient" />
                        {/* gradient end */}
                    </div>

                    <div className={`flex-1 ${styles.flexStart} flex-col xl:px-0 sm:px-16 px-6`}>
                        <div className="justify-between items-center w-full">
                        <Header
                                heading="Welcome Back :)"
                                paragraph="Don't have an account yet? "
                                linkName="Signup"
                                linkUrl="/signup"
                            />
                        <Login />
                        </div>   
                    </div>
                </div>
            </div>
        </div>
    )
}