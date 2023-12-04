import styles from "./style";
import { Search, Enroll, CTA, Footer, Navbar, Hero } from "./components";

const Home = () => (
  <div className="bg-gray-200 w-full overflow-hidden">
    <div className={`${styles.paddingX} ${styles.flexCenter}`}>
      <div className={`${styles.boxWidth}`}>
        <Navbar />
      </div>
    </div>

    <div className={`bg-dimWhite ${styles.flexStart}`}>
      <div className={`${styles.boxWidth}`}>
        <Hero />
      </div>
    </div>
    
    <div className={`bg-primary ${styles.paddingX} ${styles.flexCenter}`}>
      <div className={`${styles.boxWidth}`}>
        <Enroll />
        <Search />
        <CTA />
        <Footer />
      </div>
    </div>
    

  </div>
);

export default Home;
