/* eslint-disable jsx-a11y/anchor-has-content */
export const Focus = (props) => {
  return (
    <section id="onfocus" className="onfocus">
      <div className="container-fluid p-0" data-aos="fade-up">
        <div className="row g-0">
          <div className="col-lg-8 video-play position-relative">
            <a
              href="https://www.youtube.com/watch?v=7D6VyzkIv78"
              className="glightbox play-btn"
            />
          </div>
          <div className="col-lg-4">
            <div className="content d-flex flex-column justify-content-center h-100">
              <h3>Sản phẩm tiêu biểu</h3>
              <p className="fst-italic">
                Lễ ký kết hợp tác chiến lược phát triển các dòng sản phẩm lưu
                trữ thông minh
              </p>
              <ul>
                <li>
                  <i className="bi bi-check-circle" />
                  Giải quyết vấn đề lưu trữ hồ sơ.
                </li>
                <li>
                  <i className="bi bi-check-circle" />
                  Bảo vệ hồ sơ.
                </li>
                <li>
                  <i className="bi bi-check-circle" />
                  Giúp giảm tải sức người.
                </li>
              </ul>
              {/* <a href="!#" className="read-more align-self-start">
                <span>Read More</span>
                <i className="bi bi-arrow-right" />
              </a> */}
            </div>
          </div>
        </div>
      </div>
    </section>
  );
};
