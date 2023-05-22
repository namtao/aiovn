import { Header } from "./components/header";
import { Slider } from "./components/slider";
import { Footer } from "./components/footer";
import { About } from "./components/about";
import { FeaturedServices } from "./components/featured-services";
import { Clients } from "./components/clients";
// import { Cta } from "./components/cta";
import { Focus } from "./components/focus";
import { Features } from "./components/features";
import { Services } from "./components/services";
// import { Testimonials } from "./components/testimonials";
// import { Pricing } from "./components/pricing";
import { Faq } from "./components/faq";
import { Portfolio } from "./components/portfolio";
import { Team } from "./components/team";
import { Blog } from "./components/blog";
import { Contact } from "./components/contact";
// import { Table } from "./components/table";

// import { Gallery } from "./components/gallery";
// import { Testimonials } from "./components/testimonials";
// import { Team } from "./components/Team";
// import { Contact } from "./components/contact";
// import JsonData from "./data/data.json";
import SmoothScroll from "smooth-scroll";
import "./App.scss";

export const scroll = new SmoothScroll('a[href*="#"]', {
  speed: 1000,
  speedAsDuration: true,
});

const App = () => {
  // const [landingPageData, setLandingPageData] = useState({});
  // useEffect(() => {
  //   setLandingPageData(JsonData);
  // }, []);

  return (
    <div>
      <Header />
      <Slider />
      <main id="main">
        {/* <Table /> */}
        <FeaturedServices />
        <About />
        <Clients />
        {/* <Cta /> */}
        <Focus />
        <Features />
        <Services />
        {/* <Testimonials /> */}
        {/* <Pricing /> */}
        <Faq />
        <Portfolio />
        <Team />
        <Blog />
        <Contact />
        <a
          href="!#"
          className="scroll-top d-flex align-items-center justify-content-center"
        >
          <i className="bi bi-arrow-up-short" />
        </a>
        <div id="preloader" />
      </main>
      <Footer />
      {/* <Header data={landingPageData.Header} /> */}
      {/* <Features data={landingPageData.Features} />
      <About data={landingPageData.About} />
      <Services data={landingPageData.Services} />
      <Gallery data={landingPageData.Gallery} />
      <Testimonials data={landingPageData.Testimonials} />
      <Team data={landingPageData.Team} />
      <Contact data={landingPageData.Contact} /> */}
    </div>
  );
};

export default App;
