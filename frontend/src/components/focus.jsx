/* eslint-disable jsx-a11y/anchor-has-content */
export const Focus = (props) => {
  return (
    <section id="onfocus" className="onfocus">
      <div className="container-fluid p-0" data-aos="fade-up">
        <div className="row g-0">
          <div className="col-lg-6 video-play position-relative">
            <a
              href="https://www.youtube.com/watch?v=7D6VyzkIv78"
              className="glightbox play-btn"
            />
          </div>
          <div className="col-lg-6">
            <div className="content d-flex flex-column justify-content-center h-100">
              <h3>Voluptatem dignissimos provident quasi corporis</h3>
              <p className="fst-italic">
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do
                eiusmod tempor incididunt ut labore et dolore magna aliqua.
              </p>
              <ul>
                <li>
                  <i className="bi bi-check-circle" /> Ullamco laboris nisi ut
                  aliquip ex ea commodo consequat.
                </li>
                <li>
                  <i className="bi bi-check-circle" /> Duis aute irure dolor in
                  reprehenderit in voluptate velit.
                </li>
                <li>
                  <i className="bi bi-check-circle" /> Ullamco laboris nisi ut
                  aliquip ex ea commodo consequat. Duis aute irure dolor in
                  reprehenderit in voluptate trideta storacalaperda mastiro
                  dolore eu fugiat nulla pariatur.
                </li>
              </ul>
              <a href="!#" className="read-more align-self-start">
                <span>Read More</span>
                <i className="bi bi-arrow-right" />
              </a>
            </div>
          </div>
        </div>
      </div>
    </section>
  );
};
