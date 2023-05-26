// import { Cta } from "./components/cta";
// import { Features } from "./components/features";
// import { Testimonials } from "./components/testimonials";
// import { Pricing } from "./components/pricing";
import { Contact } from "./components/contact";
import { Home } from "./components/home";
// import { Table } from "./components/table";

// import { Gallery } from "./components/gallery";
// import { Testimonials } from "./components/testimonials";
// import { Team } from "./components/Team";
// import { Contact } from "./components/contact";
// import JsonData from "./data/data.json";
import SmoothScroll from "smooth-scroll";
import "./App.scss";
import { Routes, Route } from "react-router-dom";
import React from "react";
import { Link } from "react-router-dom";


export const scroll = new SmoothScroll('a[href*="#"]', {
  speed: 1000,
  speedAsDuration: true,
});

const App = () => {

  return (
    <div>
      <Link reloadDocument to="/">Trang chủ</Link>
      <Link to="/contact">Liên hệ</Link>

      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/contact" element={<Contact />} />
      </Routes>
    </div>
  );
};

export default App;
