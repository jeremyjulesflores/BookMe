import Header from "../components/Login-Signup/Header"
import Login from "../components/Login-Signup/Login"
import styles from "../style"
import { sample01 } from "../assets"
import GoogleLogInButton from "../components/Login-Signup/GoogleLogInButton"
import TextLink from "../components/Login-Signup/TextLink"

export default function LoginPage(){
    return(
        <div className={`${styles.paddingX} ${styles.flexCenter}`}>
            <div className={`${styles.boxWidth}`}>
                
                <div className= {`flex md:flex-row flex-col mt-15 ${styles.paddingY}`}>
                        
                    <div className={`flex-1 flex-col ${styles.flexCenter} md:my-0  my-10 relative`}>
                        
                       
                        <img src={sample01} alt="sample" className="  w-[50%] h-[100%] relative z-[5] md:w-[100%]" />
                        {/* gradient start */}
                        <div className="absolute z-[0] w-[40%] h-[35%] top-0 pink__gradient" />
                        <div className="absolute z-[1] w-[80%] h-[80%] rounded-full white__gradient bottom-40" />
                        <div className="absolute z-[0] w-[50%] h-[50%] right-20 bottom-20 blue__gradient" />
                        {/* gradient end */}
                    </div>

                    <div className={`flex-1 flex-col xl:px-0 sm:px-16 px-6 ${styles.flexCenter}`}>
                        <div className="justify-between items-center w-full">
                        <Header
                                heading="Welcome Back :)"
                                paragraph="Don't have an account yet? "
                                linkName="Signup"
                                linkUrl="/signup"
                            />
                        <div className={`${styles.flexCenter} mt-4`}>
                            <GoogleLogInButton />
                        </div>
                        {/*Separator between social media sign in and email sign in */}
                        <div
                            className="my-4 flex items-center before:mt-0.5 before:flex-1 before:border-t before:border-neutral-300 after:mt-0.5 after:flex-1 after:border-t after:border-neutral-300">
                            <p
                            className="mx-4 mb-0 text-center font-semibold">
                            Or
                            </p>
                        </div>
                        <Login />
                        {/* Button Back to Landing page */}
                        <TextLink
                            page="Landing"
                        />
                        </div>   
                    </div>
                </div>
            </div>
        </div>
    )
}