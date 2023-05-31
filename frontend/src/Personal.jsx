import { Contact } from "./components/contact";
import { Dashboard } from "./components/dashboard";
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
    <>
      <div>
        <header
          id="header"
          className="header fixed-top"
          data-scrollto-offset={0}
        >
          <div className="container-fluid d-flex align-items-center justify-content-between">
            <a
              href="index.html"
              className="logo d-flex align-items-center scrollto me-auto me-lg-0"
            >
              <h1>
                infY<span>.</span>
              </h1>
            </a>
            <nav id="navbar" className="navbar">
              <ul>
                <li>
                  <Link className="nav-link scrollto" reloadDocument to="/">
                    Trang chủ
                  </Link>
                </li>
                {/* <li className="dropdown megamenu">
                  <a className="nav-link scrollto" href="#recent-blog-posts">
                    <span>Tài liệu</span>{" "}
                    <i className="bi bi-chevron-down dropdown-indicator" />
                  </a>
                  <ul>
                    <li>
                      <a href="!#">Column 1 link 1</a>
                      <a href="!#">Column 1 link 2</a>
                      <a href="!#">Column 1 link 3</a>
                    </li>
                    <li>
                      <a href="!#">Column 2 link 1</a>
                      <a href="!#">Column 2 link 2</a>
                      <a href="!#">Column 3 link 3</a>
                    </li>
                    <li>
                      <a href="!#">Column 3 link 1</a>
                      <a href="!#">Column 3 link 2</a>
                      <a href="!#">Column 3 link 3</a>
                    </li>
                    <li>
                      <a href="!#">Column 4 link 1</a>
                      <a href="!#">Column 4 link 2</a>
                      <a href="!#">Column 4 link 3</a>
                    </li>
                  </ul>
                </li> */}
                <li className="dropdown">
                  <a href="!#">
                    <span>Kiến thức</span>{" "}
                    <i className="bi bi-chevron-down dropdown-indicator" />
                  </a>
                  <ul>
                    <li>
                      <a href="!#">Drop Down 1</a>
                    </li>
                    <li className="dropdown">
                      <a href="!#">
                        <span>Deep Drop Down</span>{" "}
                        <i className="bi bi-chevron-down dropdown-indicator" />
                      </a>
                      <ul>
                        <li>
                          <a href="!#">Deep Drop Down 1</a>
                        </li>
                        <li>
                          <a href="!#">Deep Drop Down 2</a>
                        </li>
                        <li>
                          <a href="!#">Deep Drop Down 3</a>
                        </li>
                        <li>
                          <a href="!#">Deep Drop Down 4</a>
                        </li>
                        <li>
                          <a href="!#">Deep Drop Down 5</a>
                        </li>
                      </ul>
                    </li>
                    <li>
                      <a href="!#">Drop Down 2</a>
                    </li>
                    <li>
                      <a href="!#">Drop Down 3</a>
                    </li>
                    <li>
                      <a href="!#">Drop Down 4</a>
                    </li>
                  </ul>
                </li>
                <li className="dropdown">
                  <a href="!#">
                    <span>Công cụ</span>{" "}
                    <i className="bi bi-chevron-down dropdown-indicator" />
                  </a>
                  <ul>
                    <li>
                      <a href="!#">Drop Down 1</a>
                    </li>
                    <li className="dropdown">
                      <a href="!#">
                        <span>Deep Drop Down</span>{" "}
                        <i className="bi bi-chevron-down dropdown-indicator" />
                      </a>
                      <ul>
                        <li>
                          <a href="!#">Deep Drop Down 1</a>
                        </li>
                        <li>
                          <a href="!#">Deep Drop Down 2</a>
                        </li>
                        <li>
                          <a href="!#">Deep Drop Down 3</a>
                        </li>
                        <li>
                          <a href="!#">Deep Drop Down 4</a>
                        </li>
                        <li>
                          <a href="!#">Deep Drop Down 5</a>
                        </li>
                      </ul>
                    </li>
                    <li>
                      <a href="!#">Drop Down 2</a>
                    </li>
                    <li>
                      <a href="!#">Drop Down 3</a>
                    </li>
                    <li>
                      <a href="!#">Drop Down 4</a>
                    </li>
                  </ul>
                </li>
              </ul>
              <i className="bi bi-list mobile-nav-toggle d-none" />
            </nav>
            <a className="btn-getstarted scrollto" href="index.html#contact">
              Push Github
            </a>
          </div>
        </header>

        <Routes>
          <Route path="/" element={<Dashboard />} />
          <Route path="/contact" element={<Contact />} />
        </Routes>
      </div>
    </>
  );
};

export default App;
