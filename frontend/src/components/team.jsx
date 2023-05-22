/* eslint-disable jsx-a11y/no-redundant-roles */
/* eslint-disable jsx-a11y/anchor-is-valid */
/* eslint-disable jsx-a11y/anchor-has-content */

export const Team = (props) => {
  return (
    <>
      <section id="team" className="team">
        <div className="container" data-aos="fade-up">
          <div className="section-header">
            <h2>Our Team</h2>
            <p>
              Architecto nobis eos vel nam quidem vitae temporibus voluptates
              qui hic deserunt iusto omnis nam voluptas asperiores sequi tenetur
              dolores incidunt enim voluptatem magnam cumque fuga.
            </p>
          </div>
          <div className="row gy-5">
            <div
              className="col-xl-4 col-md-6 d-flex"
              data-aos="zoom-in"
              data-aos-delay={200}
            >
              <div className="team-member">
                <div className="member-img">
                  <img src="img/team/team-1.jpg" className="img-fluid" alt="" />
                </div>
                <div className="member-info">
                  <div className="social">
                    <a href>
                      <i className="bi bi-twitter" />
                    </a>
                    <a href>
                      <i className="bi bi-facebook" />
                    </a>
                    <a href>
                      <i className="bi bi-instagram" />
                    </a>
                    <a href>
                      <i className="bi bi-linkedin" />
                    </a>
                  </div>
                  <h4>Walter White</h4>
                  <span>Chief Executive Officer</span>
                </div>
              </div>
            </div>
            {/* End Team Member */}
            <div
              className="col-xl-4 col-md-6 d-flex"
              data-aos="zoom-in"
              data-aos-delay={400}
            >
              <div className="team-member">
                <div className="member-img">
                  <img src="img/team/team-2.jpg" className="img-fluid" alt="" />
                </div>
                <div className="member-info">
                  <div className="social">
                    <a href>
                      <i className="bi bi-twitter" />
                    </a>
                    <a href>
                      <i className="bi bi-facebook" />
                    </a>
                    <a href>
                      <i className="bi bi-instagram" />
                    </a>
                    <a href>
                      <i className="bi bi-linkedin" />
                    </a>
                  </div>
                  <h4>Sarah Jhonson</h4>
                  <span>Product Manager</span>
                </div>
              </div>
            </div>
            {/* End Team Member */}
            <div
              className="col-xl-4 col-md-6 d-flex"
              data-aos="zoom-in"
              data-aos-delay={600}
            >
              <div className="team-member">
                <div className="member-img">
                  <img src="img/team/team-3.jpg" className="img-fluid" alt="" />
                </div>
                <div className="member-info">
                  <div className="social">
                    <a href>
                      <i className="bi bi-twitter" />
                    </a>
                    <a href>
                      <i className="bi bi-facebook" />
                    </a>
                    <a href>
                      <i className="bi bi-instagram" />
                    </a>
                    <a href>
                      <i className="bi bi-linkedin" />
                    </a>
                  </div>
                  <h4>William Anderson</h4>
                  <span>CTO</span>
                </div>
              </div>
            </div>
            {/* End Team Member */}
          </div>
        </div>
      </section>
    </>
  );
};
