export const Cta = (props) => {
  return (
    <section id="cta" className="cta">
      <div className="container" data-aos="zoom-out">
        <div className="row g-5">
          <div className="col-lg-8 col-md-6 content d-flex flex-column justify-content-center order-last order-md-first">
            <h3>
              Alias sunt quas <em>Cupiditate</em> oluptas hic minima
            </h3>
            <p>
              {" "}
              Duis aute irure dolor in reprehenderit in voluptate velit esse
              cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat
              cupidatat non proident, sunt in culpa qui officia deserunt mollit
              anim id est laborum.
            </p>
            <a className="cta-btn align-self-start" href="!#">
              Call To Action
            </a>
          </div>
          <div className="col-lg-4 col-md-6 order-first order-md-last d-flex align-items-center">
            <div className="img">
              <img src="img/cta.jpg" alt="" className="img-fluid" />
            </div>
          </div>
        </div>
      </div>
    </section>
  );
};
