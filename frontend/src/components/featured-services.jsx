export const FeaturedServices = (props) => {
  return (
    <section id="featured-services" className="featured-services">
      <div className="container">
        <div className="row gy-4">
          <div className="col-xl-3 col-md-6 d-flex" data-aos="zoom-out">
            <div className="service-item position-relative">
              <div className="icon">
                <i className="bi bi-activity icon" />
              </div>
              <h4>
                <a href className="stretched-link">
                  Số hóa tài liệu
                </a>
              </h4>
              <p>
                Thực hiện chuyên nghiệp, khoa học, bảo mật, đảm bảo chính xác
                thông tin số hóa.
              </p>
            </div>
          </div>
          {/* End Service Item */}
          <div
            className="col-xl-3 col-md-6 d-flex"
            data-aos="zoom-out"
            data-aos-delay={200}
          >
            <div className="service-item position-relative">
              <div className="icon">
                <i className="bi bi-bounding-box-circles icon" />
              </div>
              <h4>
                <a href className="stretched-link">
                  Chỉnh lý hồ sơ
                </a>
              </h4>
              <p>
                ADDJ là đơn vị hàng đầu trong nhiều năm liền, là đơn vị tiên
                phong ứng dụng khoa học công nghệ vào dịch vụ chỉnh lý hồ sơ.
              </p>
            </div>
          </div>
          {/* End Service Item */}
          <div
            className="col-xl-3 col-md-6 d-flex"
            data-aos="zoom-out"
            data-aos-delay={400}
          >
            <div className="service-item position-relative">
              <div className="icon">
                <i className="bi bi-calendar4-week icon" />
              </div>
              <h4>
                <a href className="stretched-link">
                  Trang thiết bị lưu trữ
                </a>
              </h4>
              <p>
                ADDJ là đơn vị sản xuất các thiết bị phục vụ cho hành chính, đặc
                biệt là các giá đỡ, khung, bìa hồ sơ, hộp bảo quản giấy tờ tiêu
                chuẩn quốc tế.
              </p>
            </div>
          </div>
          {/* End Service Item */}
          <div
            className="col-xl-3 col-md-6 d-flex"
            data-aos="zoom-out"
            data-aos-delay={600}
          >
            <div className="service-item position-relative">
              <div className="icon">
                <i className="bi bi-broadcast icon" />
              </div>
              <h4>
                <a href className="stretched-link">
                  Phần mềm
                </a>
              </h4>
              <p>
                ADDJ cũng là đơn vị cung cấp các phần mềm chuyên dụng cho các đơn vị nhằm khai thác, quản lý hồ sơ điện tử.
              </p>
            </div>
          </div>
          {/* End Service Item */}
        </div>
      </div>
    </section>
  );
};
