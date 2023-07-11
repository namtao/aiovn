/* eslint-disable jsx-a11y/no-redundant-roles */
export const Contact = (props) => {
  return (
    <section id="contact" className="contact">
      <div className="container">
        <div className="section-header">
          <h2>Liên hệ với chúng tôi</h2>
          {/* <p>
            Ea vitae aspernatur deserunt voluptatem impedit deserunt magnam
            occaecati dssumenda quas ut ad dolores adipisci aliquam.
          </p> */}
        </div>
      </div>
      <div className="map">
        {/* <iframe
              src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d12097.433213460943!2d-74.0062269!3d40.7101282!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0xb89d1fe6bc499443!2sDowntown+Conference+Center!5e0!3m2!1smk!2sbg!4v1539943755621"
              frameBorder={0}
              allowFullScreen
            /> */}
      </div>
      {/* End Google Maps */}
      <div className="container">
        <div className="row gy-5 gx-lg-5">
          <div className="col-lg-4">
            <div className="info">
              <h3>Get in touch</h3>
              <p>
                Et id eius voluptates atque nihil voluptatem enim in tempore
                minima sit ad mollitia commodi minus.
              </p>
              <div className="info-item d-flex">
                <i className="bi bi-geo-alt flex-shrink-0" />
                <div>
                  <h4>Địa chỉ:</h4>
                  <p>
                    Số 3A, Ngách 3, Ngõ 514 Thụy Khuê, Phường Bưởi, Quận Tây Hồ,
                    TP. Hà Nội
                  </p>
                </div>
              </div>
              {/* End Info Item */}
              {/* <div className="info-item d-flex">
                <i className="bi bi-envelope flex-shrink-0" />
                <div>
                  <h4>Email:</h4>
                  <p>info@example.com</p>
                </div>
              </div> */}
              {/* End Info Item */}
              <div className="info-item d-flex">
                <i className="bi bi-phone flex-shrink-0" />
                <div>
                  <h4>Điện thoại:</h4>
                  <p>+84 913 014 506</p>
                </div>
              </div>
              {/* End Info Item */}
            </div>
          </div>
          <div className="col-lg-8">
            <form
              action="forms/contact.php"
              method="post"
              role="form"
              className="php-email-form"
            >
              <div className="row">
                <div className="col-md-6 form-group">
                  <input
                    type="text"
                    name="name"
                    className="form-control"
                    id="name"
                    placeholder="Họ và tên"
                    required
                  />
                </div>
                <div className="col-md-6 form-group mt-3 mt-md-0">
                  <input
                    type="email"
                    className="form-control"
                    name="email"
                    id="email"
                    placeholder="Email"
                    required
                  />
                </div>
              </div>
              <div className="form-group mt-3">
                <input
                  type="text"
                  className="form-control"
                  name="subject"
                  id="subject"
                  placeholder="Tiêu đề"
                  required
                />
              </div>
              <div className="form-group mt-3">
                <textarea
                  className="form-control"
                  name="message"
                  placeholder="Nội dung"
                  required
                  defaultValue={""}
                />
              </div>
              <div className="my-3">
                <div className="loading">Loading</div>
                <div className="error-message" />
                <div className="sent-message">Thư đã được gửi, xin cảm ơn!</div>
              </div>
              <div className="text-center">
                <button type="submit">Gửi thư</button>
              </div>
            </form>
          </div>
          {/* End Contact Form */}
        </div>
      </div>
    </section>
  );
};