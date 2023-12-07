import { useEffect } from "react";
import { features } from "../constants";
import styles, { layout } from "../style";
import Button from "./Button";
import AOS from 'aos'
import 'aos/dist/aos.css'


const FeatureCard = ({ icon, title, content, index }) => (
  <div className={`flex flex-row p-6 rounded-[20px] ${index !== features.length - 1 ? "mb-6" : "mb-0"} feature-card`} data-aos="fade-left" >
    <div className={`w-[64px] h-[64px] rounded-full ${styles.flexCenter} bg-dimBlue`}>
      <img src={icon} alt="star" className="w-[50%] h-[50%] object-contain" />
    </div>
    <div className="flex-1 flex flex-col ml-3">
      <h4 className="font-poppins font-semibold text-white text-[18px] leading-[23.4px] mb-1">
        {title}
      </h4>
      <p className="font-poppins font-normal text-dimWhite text-[16px] leading-[24px]">
        {content}
      </p>
    </div>
  </div>
);

const Enroll = () =>  {
  useEffect(() => {
    AOS.init();
  }, []);
  return(
  <section id="enroll" className={layout.section}>
      <div className={layout.sectionInfo} data-aos="fade-right">
        <h2 className={styles.heading2}>
          You do the business, <br className="sm:block hidden" /> we’ll handle
          your bookings.
        </h2>
        <p className={`${styles.paragraph} max-w-[470px] mt-5`}>
          With BookMe, you can focus on improving your business while we worry about you getting booked. Put yourself on the market now!
        </p>

        <Button styles={`mt-10 bg-gray-500  hover:bg-gray-600 `} text ={'Enroll your business'} link={'/signup'}/>
      </div>

      <div className={`${layout.sectionImg} flex-col`}>
        {features.map((feature, index) => (
          <FeatureCard key={feature.id} {...feature} index={index} />
        ))}
      </div>
    </section>
  );
  
};

export default Enroll;
