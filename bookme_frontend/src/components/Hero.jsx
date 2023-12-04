import styles from "../style";
import { discount, sample01, sample02, sample03, sample04} from "../assets";
import Slider from "react-slick";
import 'slick-carousel/slick/slick.css';
import 'slick-carousel/slick/slick-theme.css';

const images = [sample01, sample02, sample03, sample04];

const Hero = () => {
  const settings = {
    dots: true,
    infinite: true,
    speed: 500,
    slidesToShow: 1,
    slidesToScroll: 1,
    autoplay: true, 
    autoplaySpeed: 3000, 
  };
  return (
    <section id="home" className={`flex md:flex-row flex-col ${styles.paddingY}`}>
      <div className={`flex-1 ${styles.flexStart} flex-col xl:px-0 sm:px-16 px-6`}>
       

        <div className="flex flex-row justify-between items-center w-full">
          <h1 className="flex-1 font-poppins font-semibold ss:text-[72px] text-[52px] text-gray-400 ss:leading-[100.8px] leading-[75px]">
            Book <br className="sm:block hidden" />{" "}
            <span className="text-gray-900">Anything,</span>{" "}
          </h1>
        </div>

        <h1 className="font-poppins font-semibold ss:text-[68px] text-[52px] text-gray-400 ss:leading-[100.8px] leading-[75px] w-full">
          Anytime
        </h1>
        <p className={`${styles.paragraph} max-w-[470px] mt-5 text-gray-800`}>
          Put your services online for customers to book anytime
        </p>
      </div>

      <div className={`flex-1 flex ${styles.flexCenter} md:my-0 my-10 relative`}>
        {/* <div className="w-[100%] h-[100%] relative z-[5]">
          <Slider {...settings} >
            {images.map((image, index) => (
              <img key={index} src={image} alt={`sample-${index + 1}`} />
            ))}
          </Slider>
        </div> */}

        <img src={sample03} alt="sample" className="w-[100%] h-[100%] relative z-[5]" />
        

        {/* gradient start */}
        <div className="absolute z-[0] w-[40%] h-[35%] top-0 pink__gradient" />
        <div className="absolute z-[1] w-[80%] h-[80%] rounded-full white__gradient bottom-40" />
        <div className="absolute z-[0] w-[50%] h-[50%] right-20 bottom-20 blue__gradient" />
        {/* gradient end */}
      </div>

    </section>
  );
};

export default Hero;
