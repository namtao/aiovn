# Random forest

- Bias là sự sai khác giữa trung bình dự đoán của mô hình chúng ta xây dựng với giá trị chính xác đang cố gắng để dự đoán. Một mô hình với trị số bias cao đồng nghĩa với việc mô hình đó không quan tâm nhiều tới dữ liệu huấn luyện, khiến cho mô hình trở nên đơn giản quá. Nó thường dẫn đến việc mô hình có mức độ lỗi cao cả trên tập huấn luyện và tập kiểm thử.
- Variance đặc trưng cho mức độ tản mát của giá trị dự đoán cho điểm dữ liệu. Mô hình với mức độ variance cao tập trung chú ý nhiều vào dữ liệu huấn luyện và không mang được tính tổng quát trên dữ liệu chưa gặp bao giờ. Từ đó dẫn đến mô hình đạt được kết quả cực kì tốt trên tập dữ liệu huấn luyện, tuy nhiên kết quả rất tệ với tập dữ liệu kiểm thử.

- Ensemple learning
  - Bagging: xây dựng N cây sau đó tổng hợp thành 1 cây duy nhất (Strong classifier) - Random forest
  - Boosting: xây dựng cây N từ cây thứ N-1 để cải thiện độ chính xác của cây trước đó
  - Stacking: mỗi dataset sẽ sử dụng các giải thuật khác nhau để xử lý trước cho ra 1 đầu ra theo chuẩn mới để đưa vào mô hình huấn luyện
- Homogeneous Approach

- Xây dựng random forest
  - Lấy ngẫu nhiên n dữ liệu từ bộ dữ liệu với kĩ thuật $Bootstrapping$, hay còn gọi là random sampling with replacement. Tức khi mình sample được 1 dữ liệu thì mình không bỏ dữ liệu đấy ra mà vẫn giữ lại trong tập dữ liệu ban đầu, rồi tiếp tục sample cho tới khi sample đủ n dữ liệu. Khi dùng kĩ thuật này thì tập n dữ liệu mới của mình có thể có những dữ liệu bị trùng nhau.
  - Sau khi sample được n dữ liệu từ bước 1 thì mình chọn ngẫu nhiên ở k thuộc tính (k < n). Giờ mình được bộ dữ liệu mới gồm n dữ liệu và mỗi dữ liệu có k thuộc tính
  - Dùng thuật toán Decision Tree để xây dựng cây quyết định với bộ dữ liệu ở bước 2
  - Loại bỏ feature root node ra khỏi dataset và chọn ngẫu nhiên 2 feature còn lại và đánh giá lựa chọn root node
  - Tiếp tục quá trình đến khi hết feature
  - Xây dựng N tree song song như trên
- Out of bag error

## Tại sao thuật toán Random Forest tốt?

- Trong thuật toán Decision Tree, khi xây dựng cây quyết định nếu để độ sâu tùy ý thì cây sẽ phân loại đúng hết các dữ liệu trong tập training dẫn đến mô hình có thể dự đoán tệ trên tập validation/test, khi đó mô hình bị overfitting, hay nói cách khác là mô hình có high variance.

[Tham khảo]

## Random forest with missing data

- Khởi tạo giá trị bàn đầu bằng trung bình, trung vị, voting của các sample để điền vào data missing
- Proximity matrix: để xác định số cây dự đoán giống nhau

[Tham khảo]: https://machinelearningcoban.com/tabml_book/ch_model/random_forest.html
