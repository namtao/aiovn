export const Pricing = (props) => {
  return (
    <section id="pricing" className="pricing">
      <div className="container" data-aos="fade-up">
        <div className="section-header">
          <h2>Our Pricing</h2>
          <p>
            Architecto nobis eos vel nam quidem vitae temporibus voluptates qui
            hic deserunt iusto omnis nam voluptas asperiores sequi tenetur
            dolores incidunt enim voluptatem magnam cumque fuga.
          </p>
        </div>
        <div className="row gy-4">
          <div className="col-lg-4" data-aos="zoom-in" data-aos-delay={200}>
            <div className="pricing-item">
              <div className="pricing-header">
                <h3>Free Plan</h3>
                <h4>
                  <sup>$</sup>0<span> / month</span>
                </h4>
              </div>
              <ul>
                <li>
                  <i className="bi bi-dot" />{" "}
                  <span>Quam adipiscing vitae proin</span>
                </li>
                <li>
                  <i className="bi bi-dot" />{" "}
                  <span>Nec feugiat nisl pretium</span>
                </li>
                <li>
                  <i className="bi bi-dot" />{" "}
                  <span>Nulla at volutpat diam uteera</span>
                </li>
                <li className="na">
                  <i className="bi bi-x" />{" "}
                  <span>Pharetra massa massa ultricies</span>
                </li>
                <li className="na">
                  <i className="bi bi-x" />{" "}
                  <span>Massa ultricies mi quis hendrerit</span>
                </li>
              </ul>
              <div className="text-center mt-auto">
                <a href="!#" className="buy-btn">
                  Buy Now
                </a>
              </div>
            </div>
          </div>
          {/* End Pricing Item */}
          <div className="col-lg-4" data-aos="zoom-in" data-aos-delay={400}>
            <div className="pricing-item featured">
              <div className="pricing-header">
                <h3>Business Plan</h3>
                <h4>
                  <sup>$</sup>29<span> / month</span>
                </h4>
              </div>
              <ul>
                <li>
                  <i className="bi bi-dot" />{" "}
                  <span>Quam adipiscing vitae proin</span>
                </li>
                <li>
                  <i className="bi bi-dot" />{" "}
                  <span>Nec feugiat nisl pretium</span>
                </li>
                <li>
                  <i className="bi bi-dot" />{" "}
                  <span>Nulla at volutpat diam uteera</span>
                </li>
                <li>
                  <i className="bi bi-dot" />{" "}
                  <span>Pharetra massa massa ultricies</span>
                </li>
                <li>
                  <i className="bi bi-dot" />{" "}
                  <span>Massa ultricies mi quis hendrerit</span>
                </li>
              </ul>
              <div className="text-center mt-auto">
                <a href="!#" className="buy-btn">
                  Buy Now
                </a>
              </div>
            </div>
          </div>
          {/* End Pricing Item */}
          <div className="col-lg-4" data-aos="zoom-in" data-aos-delay={600}>
            <div className="pricing-item">
              <div className="pricing-header">
                <h3>Developer Plan</h3>
                <h4>
                  <sup>$</sup>49<span> / month</span>
                </h4>
              </div>
              <ul>
                <li>
                  <i className="bi bi-dot" />{" "}
                  <span>Quam adipiscing vitae proin</span>
                </li>
                <li>
                  <i className="bi bi-dot" />{" "}
                  <span>Nec feugiat nisl pretium</span>
                </li>
                <li>
                  <i className="bi bi-dot" />{" "}
                  <span>Nulla at volutpat diam uteera</span>
                </li>
                <li>
                  <i className="bi bi-dot" />{" "}
                  <span>Pharetra massa massa ultricies</span>
                </li>
                <li>
                  <i className="bi bi-dot" />{" "}
                  <span>Massa ultricies mi quis hendrerit</span>
                </li>
              </ul>
              <div className="text-center mt-auto">
                <a href="!#" className="buy-btn">
                  Buy Now
                </a>
              </div>
            </div>
          </div>
          {/* End Pricing Item */}
        </div>
      </div>
    </section>
  );
};
