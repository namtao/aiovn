# K-Nearest Neighbors

- Tìm k điểm gần nhất của dữ liệu mới
- Lazy learning (instance-based learning): không cần tranning, đi tìm có tỷ lệ gần giống cao nhất
- Với KNN, trong bài toán Classification, label của một điểm dữ liệu mới (hay kết quả của câu hỏi trong bài thi) được suy ra trực tiếp từ K điểm dữ liệu gần nhất trong training set. Label của một test data có thể được quyết định bằng major voting (bầu chọn theo số phiếu) giữa các điểm gần nhất, hoặc nó có thể được suy ra bằng cách đánh trọng số khác nhau cho mỗi trong các điểm gần nhất đó rồi suy ra label.

- Trong bài toán Regresssion, đầu ra của một điểm dữ liệu sẽ bằng chính đầu ra của điểm dữ liệu đã biết gần nhất (trong trường hợp K=1), hoặc là trung bình có trọng số của đầu ra của những điểm gần nhất, hoặc bằng một mối quan hệ dựa trên khoảng cách tới các điểm gần nhất đó.

- Một cách ngắn gọn, KNN là thuật toán đi tìm đầu ra của một điểm dữ liệu mới bằng cách chỉ dựa trên thông tin của K điểm dữ liệu trong training set gần nó nhất (K-lân cận), không quan tâm đến việc có một vài điểm dữ liệu trong những điểm gần nhất này là nhiễu. Hình dưới đây là một ví dụ về KNN trong classification với K = 1.

## KNN for classification

- Xử lý dữ liệu
- Chọn K giá trị nhỏ nhất
- Tính khoảng cách với cách điểm còn lại
- Sắp xếp các điểm
- Lấy K điểm
- Chọn theo số đông

## KNN for regression

- Chọn K
- Tính khoảng cách
- Tìm K điểm gần nhất
- Tính trung bình (mean, median,...)

## KNN with brute-force

- Tính khoảng cách từ điểm mới đến tất cả các điểm còn lại trong dataset (vét cạn)

## KNN with K-D tree

- Thay vì tính khoảng cách từ điểm mới đến tất cả các điểm còn lại trong dataset?
- Tìm K điểm gần nhất 1 cách nhanh nhất
- Chọn ngẫu nhiên 1 feature
- Tính median => Chia dataset thành 2 nửa
- Chọn feature kế tiếp
- Tính median theo feture kế tiếp => ta được 1 cây phân loại dữ liệu để tìm K điểm gần nhất nhanh nhất
- Fit trong sklearn: sắp xếp dữ liệu theo 1 từng loại thuật toán sử dụng để tìm kiếm dữ liệu nhanh hơn

## KNN with ball tree

- Lấy bất kì 1 điểm
- Tìm điểm xa nhất từ điểm mới
- Tìm điểm xa nhất từ điểm mới tìm được
- Chiếu tất cả các điểm lên đường thẳng
- Tìm median trên đường thẳng
- Tìm tâm đại diện cho 2 khoảng được phân chia từ median
- Tiếp tục chia trong các khoảng được chia
- Khi có dữ liệu mới, ta tính khoảng cách ngắn nhất từ điểm mới đến tâm đường tròn đã được xây dựng bên trên dựa theo đường median
