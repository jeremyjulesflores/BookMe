import { useEffect } from "react";
import { sample04 } from "../assets";
import styles, { layout } from "../style";
import Button from "./Button";
import AOS from 'aos'
import 'aos/dist/aos.css'

const Search = () => {

  useEffect(()=>{
    AOS.init();
  },[]);
  return(
    <section id="search" className={layout.sectionReverse}>
      <div className={layout.sectionImgReverse}>
        <img src={sample04} alt="sample" className="w-[100%] h-[100%] relative z-[5]" data-aos="zoom-in" duration = "3000"/>

        {/* gradient start */}
        <div className="absolute z-[3] -left-1/2 top-0 w-[50%] h-[50%] rounded-full white__gradient" data-aos="zoom-in" duration = "1500"/>
        <div className="absolute z-[0] w-[50%] h-[50%] -left-1/2 bottom-0 rounded-full pink__gradient" data-aos="zoom-in" duration = "3500"/>
        {/* gradient end */}
      </div>

      <div className={layout.sectionInfo} data-aos="fade-left">
        <h2 className={styles.heading2}>
          Look for different services  <br className="sm:block hidden" /> offered here!
        </h2>
        <Button styles={`mt-10`} text ={'Look for services'} />


      </div>
    </section>
  )
};

export default Search;
