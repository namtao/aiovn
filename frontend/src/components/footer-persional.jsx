export const Footer = (props) => {
  return (
    //   {/* ======= infY Section ======= */ }
    <>
      <footer id="footer" className="footer">
        <div className="footer-content">
          <div className="container">
            <div className="row">
              <div className="col-lg-3 col-md-6">
                <div className="footer-info">
                  <h3>infY<span>.</span></h3>
                  <p>
                    CTCP Phát triển Công nghệ Hành chính ADDJ
                    <br />
                    Chuyên nghiệp - Khoa học - Bảo
                    mật
                    <br />
                    {/* <strong>Email:</strong> info@example.com
                    <br /> */}
                  </p>
                </div>
              </div>
              <div className="col-lg-2 col-md-6 footer-links">
                <h4>Useful Links</h4>
                <ul>
                  <li>
                    <i className="bi bi-chevron-right" /> <a href="!#">Home</a>
                  </li>
                  <li>
                    <i className="bi bi-chevron-right" />{" "}
                    <a href="!#">About us</a>
                  </li>
                  <li>
                    <i className="bi bi-chevron-right" />{" "}
                    <a href="!#">Services</a>
                  </li>
                  <li>
                    <i className="bi bi-chevron-right" />{" "}
                    <a href="!#">Terms of service</a>
                  </li>
                  <li>
                    <i className="bi bi-chevron-right" />{" "}
                    <a href="!#">Privacy policy</a>
                  </li>
                </ul>
              </div>
              <div className="col-lg-3 col-md-6 footer-links">
                <h4>Our Services</h4>
                <ul>
                  <li>
                    <i className="bi bi-chevron-right" />{" "}
                    <a href="!#">Web Design</a>
                  </li>
                  <li>
                    <i className="bi bi-chevron-right" />{" "}
                    <a href="!#">Web Development</a>
                  </li>
                  <li>
                    <i className="bi bi-chevron-right" />{" "}
                    <a href="!#">Product Management</a>
                  </li>
                  <li>
                    <i className="bi bi-chevron-right" />{" "}
                    <a href="!#">Marketing</a>
                  </li>
                  <li>
                    <i className="bi bi-chevron-right" />{" "}
                    <a href="!#">Graphic Design</a>
                  </li>
                </ul>
              </div>
              {/* <div className="col-lg-4 col-md-6 footer-newsletter">
                <h4>Our Newsletter</h4>
                <p>
                  Tamen quem nulla quae legam multos aute sint culpa legam
                  noster magna
                </p>
                <form action method="post">
                  <input type="email" name="email" />
                  <input type="submit" defaultValue="Subscribe" />
                </form>
              </div> */}
            </div>
          </div>
        </div>
        <div className="footer-legal text-center">
          <div className="container d-flex flex-column flex-lg-row justify-content-center justify-content-lg-between align-items-center">
            <div className="d-flex flex-column align-items-center align-items-lg-start">
              <div className="copyright">
                © Copyright{" "}
                <strong>
                  <span>ADDJ</span>
                </strong>
                . All Rights Reserved
              </div>
            </div>
            <div className="social-links order-first order-lg-last mb-3 mb-lg-0">
              <a href="!#" className="twitter">
                <i className="bi bi-twitter" />
              </a>
              <a href="!#" className="facebook">
                <i className="bi bi-facebook" />
              </a>
              <a href="!#" className="instagram">
                <i className="bi bi-instagram" />
              </a>
              <a href="!#" className="google-plus">
                <i className="bi bi-skype" />
              </a>
              <a href="!#" className="linkedin">
                <i className="bi bi-linkedin" />
              </a>
            </div>
          </div>
        </div>
      </footer>
    </>
    //   {/* End infY Section */}
  );
};
