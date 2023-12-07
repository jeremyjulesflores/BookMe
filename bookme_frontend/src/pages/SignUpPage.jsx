import Header from "../components/Login-Signup/Header"
import styles from "../style"
import { sample02 } from "../assets"
import Signup from "../components/Login-Signup/Signup"
import Button from "../components/Button"

export default function SignUpPage(){
    return(
        <div className={`${styles.paddingX} ${styles.flexCenter}`}>
            <div className={`${styles.boxWidth}`}>
                <div className= {`flex md:flex-row flex-col ${styles.paddingY}`}>
                        <div>
                            {/* Back Button */}
                            <Button styles={`mt-10 bg-transparent`} text ={'Back'} link={'/'}/>
                        </div>
                    <div className={`flex-1 flex ${styles.flexCenter} md:my-0 my-10 relative`}>

                        <img src={sample02} alt="sample" className="  w-[50%] h-[100%] relative z-[5] md:w-[100%]" />
                        
                        {/* gradient start */}
                        <div className="absolute z-[0] w-[40%] h-[35%] top-0 pink__gradient" />
                        <div className="absolute z-[1] w-[80%] h-[80%] rounded-full white__gradient bottom-40" />
                        <div className="absolute z-[0] w-[50%] h-[50%] right-20 bottom-20 blue__gradient" />
                        {/* gradient end */}
                    </div>

                    <div className={`flex-1 ${styles.flexStart} flex-col xl:px-0 sm:px-16 px-6`}>
                        <div className="justify-between items-center w-full">
                        <Header
                                heading="Join us :)"
                                paragraph="Already have an account? "
                                linkName="Login"
                                linkUrl="/login"
                            />
                        <Signup/>
                        </div>   
                    </div>
                </div>
            </div>
        </div>
    )
}