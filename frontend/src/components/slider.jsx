export const Slider = (props) => {
  return (
    <section
      id="infY"
      className="infY carousel  carousel-fade"
      data-bs-ride="carousel"
      data-bs-interval={5000}
    >
      <div className="carousel-inner">
        {/* ADDJ */}
        <div className="carousel-item active">
          <div className="container">
            <div className="row justify-content-center gy-6">
              <div className="col-lg-5 col-md-8">
                <img
                  src="img/carousel/addj-removebg.png"
                  alt=""
                  className="img-fluid img"
                />
              </div>
              <div className="col-lg-9 text-center">
                <h2>CTCP Phát triển Công nghệ Hành chính ADDJ</h2>
                <h3>Chuyên nghiệp - Khoa học - Bảo mật</h3>
                <p>
                  Chúng tôi tự hào là đơn vị tiên phong trong lĩnh vực số hóa,
                  chỉnh lý tài liệu giấy cùng với việc sản xuất các trang thiết
                  bị chuyên nghiệp và hiện đại.
                </p>
                <a
                  href="#featured-services"
                  className="btn-get-started scrollto "
                >
                  Bắt đầu
                </a>
              </div>
            </div>
          </div>
        </div>
        {/* Số hóa */}
        <div className="carousel-item">
          <div className="container">
            <div className="row justify-content-center gy-6">
              <div className="col-lg-5 col-md-8">
                <img
                  src="img/carousel/carousel-1.png"
                  alt=""
                  className="img-fluid img"
                />
              </div>
              <div className="col-lg-9 text-center">
                <h2>Dịch vụ số hóa tài liệu</h2>
                <p>
                  Số hóa tài liệu là công việc chuyển đổi các dạng tài liệu
                  truyền thống: chữ viết tay, bản in, âm thanh, hình ảnh,… sang
                  chuẩn tài liệu mà máy tính có thể nhận biết được. Các tài liệu
                  đã được số hóa sẽ được lưu trữ trên máy chủ riêng hoặc trên
                  nền tảng đám mây. Sau khi được số hóa, tài liệu sẽ dễ dàng
                  quản lý hơn với một lượng không gian nhất định. Bạn không còn
                  phải lo lắng việc bảo quản hay làm mất các tài liệu quan
                  trọng.
                </p>
                <a
                  href="#featured-services"
                  className="btn-get-started scrollto "
                >
                  Bắt đầu
                </a>
              </div>
            </div>
          </div>
        </div>
        {/* Chỉnh lý */}
        <div className="carousel-item">
          <div className="container">
            <div className="row justify-content-center gy-6">
              <div className="col-lg-5 col-md-8">
                <img
                  src="img/carousel/carousel-2.png"
                  alt=""
                  className="img-fluid img"
                />
              </div>
              <div className="col-lg-9 text-center">
                <h2>Dịch vụ chỉnh lý tài liệu</h2>
                <p>
                  Chỉnh lý tài liệu là tổ chức lại tài liệu theo một phương án
                  phân loại khoa học, trong đó tiến hành chỉnh sửa hoàn thiện,
                  phục hồi hoặc lập mới hồ sơ; xác định giá trị; hệ thống hoá hồ
                  sơ, tài liệu và làm các công cụ tra cứu đối với phông hoặc
                  khối tài liệu đưa ra chỉnh lý.
                </p>
                <a
                  href="#featured-services"
                  className="btn-get-started scrollto "
                >
                  Bắt đầu
                </a>
              </div>
            </div>
          </div>
        </div>
        {/* Trang thiết bị */}
        <div className="carousel-item">
          <div className="container">
            <div className="row justify-content-center gy-6">
              <div className="col-lg-5 col-md-8">
                <img
                  src="img/carousel/carousel-3.svg"
                  alt=""
                  className="img-fluid img"
                />
              </div>
              <div className="col-lg-9 text-center">
                <h2>Trang thiết bị kho lưu trữ</h2>
                <p>
                  Kho lưu trữ chuyên dụng là công trình bao gồm: khu vực kho bảo
                  quản tài liệu, khu vực xử lý nghiệp vụ lưu trữ, khu hành
                  chính, khu vực lắp đặt thiết bị kỹ thuật và khu vực phục vụ
                  công chúng.
                </p>
                <a
                  href="#featured-services"
                  className="btn-get-started scrollto "
                >
                  Bắt đầu
                </a>
              </div>
            </div>
          </div>
        </div>
      </div>
      <a
        className="carousel-control-prev"
        href="#infY"
        role="button"
        data-bs-slide="prev"
      >
        <span
          className="carousel-control-prev-icon bi bi-chevron-left"
          aria-hidden="true"
        />
      </a>
      <a
        className="carousel-control-next"
        href="#infY"
        role="button"
        data-bs-slide="next"
      >
        <span
          className="carousel-control-next-icon bi bi-chevron-right"
          aria-hidden="true"
        />
      </a>
      <ol className="carousel-indicators" />
    </section>
  );
};
