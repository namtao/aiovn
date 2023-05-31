// import { Slider } from "./slider";
import { Footer } from "./footer-persional";
// import { About } from "./about";
// import { FeaturedServices } from "./featured-services";
// import { Clients } from "./clients";
// import { Focus } from "./focus";
// import { Services } from "./services";
// import { Faq } from "./faq";
// import { Product } from "./product";
// import { Team } from "./team";
// import { News } from "./news";
// import { Contact } from "./contact";
import SmoothScroll from "smooth-scroll";
// import "../App.scss";
// import { Digitizing } from "./digitizing";
// import { Readjust } from "./readjust";
// import { Equipment } from "./equipment";
import React from "react";

export const scroll = new SmoothScroll('a[href*="#"]', {
  speed: 1000,
  speedAsDuration: true,
});

export const Dashboard = () => {
  // const [landingPageData, setLandingPageData] = useState({});
  // useEffect(() => {
  //   setLandingPageData(JsonData);
  // }, []);

  return (
    <div>
      {/* <Slider /> */}
      <main id="main">
        {/* <Table /> */}
        {/* <FeaturedServices /> */}
        {/* <About /> */}
        {/* <Clients /> */}
        {/* <Digitizing /> */}
        {/* <Readjust /> */}
        {/* <Equipment /> */}
        {/* <Cta /> */}
        {/* <Focus /> */}
        {/* <Features /> */}
        {/* <Services /> */}
        {/* <Testimonials /> */}
        {/* <Pricing /> */}
        {/* <Faq /> */}
        {/* <Product /> */}
        {/* <Team /> */}
        {/* <News /> */}
        {/* <Contact /> */}

        <a
          href="!#"
          className="scroll-top d-flex align-items-center justify-content-center"
        >
          <i className="bi bi-arrow-up-short" />
        </a>
        <div id="preloader" />
      </main>
      <Footer />
    </div>
  );
};
