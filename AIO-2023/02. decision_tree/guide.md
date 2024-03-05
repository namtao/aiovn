# Decision tree

- Khắc phục nhược điểm của KNN là tốn nhiều thời gian đối với dữ liệu lớn
- Purity: dataset thuần khiết, kết quả chỉ thuộc về 1 lớp

## Root Node

- Gini: chọn min $\to$ purity
- Entropy: chọn information gain max

## Decision tree with Gini

$$ Gini (D) =  1 - \sum_{i = 1}^{k}p_{i}^{2} $$

If a data set D is split on an attribute A into two subsets $D_1$ and $D_2$ with sizes $n_1$ and $n_2$, respectively, the Gini Impurity can be defined as:

$$ Gini_A(D) = \frac{n_1}{n}Gini(D_1) +  \frac{n_2}{n}Gini(D_2)  $$

## Decision tree with Entropy

- Entropy dựa vào log để hợp thức hoá độ dài khoảng cách theo số lần của các đối tượng khác nhau, chiếu sang dạng 1 trục số khác theo đúng tỷ lệ như ngôn ngữ nói
- Entropy là trung bình độ ngạc nhiên khi 1 sự kiện xảy ra
- Tính độ ngạc nhiên $S = log_2(\frac{1}{P})$
- Log base 2
- Information gain là từ 1 vấn đề có độ ngạc nhiên cao chuyển về độ ngạc nhiên thấp do được cung cấp nhiều thông tin $\to$ max information gain

$$ E = - \sum_{i =1}^{N}p_ilog_2p_i $$

$$Information\ gain:\ IG(S, F) = E(S) - \sum_{f \in F} \frac{|S_f|}{|S|}E(S_f)$$

- Tính toán tất cả các feature để tìm root node thông qua IG max
- Lặp lại quá trình để chia thành cây nhị phân phân chia dữ liệu

## Decision tree for classification

- Gini
- Entropy
- Vote
- Phân loại dữ liệu sao cho độ tin cậy để xác định dữ liệu thuộc về 1 feature nào đó cao nhất

## Decision tree for regression

- Bài toán về regression là chia nhỏ dữ liệu và tính trung bình của đoạn dữ liệu đó sao cho đường đại diện cho đoạn dữ liệu có độ lệch trung bình nhỏ tốt nhất, đại diện tối ưu nhất cho đoạn dữ liệu đó.
- Tìm ngưỡng của dataset
  - Từ trái qua phải, ta lấy 2 điểm liền kề đầu tiên và lấy giá trị trung bình của 2 điểm đó (ở đây trung bình sẽ là 3)
  - Từ trung bình ở trên, ta đã chia dữ liệu thành 2 phần trái và phải. Tiếp theo ta tiến hành lấy giá trị trung bình của mỗi phía
  - Theo dataset ta có được trung bình bên trái là 0, trung bình bên phải sẽ là 38.8
  - Ta đã có được 1 thành phần cây: nếu Unit < 3 thì hiệu quả sẽ = 0, ngược lại hiệu quả đạt 38.8
  - Tiến hành đánh giá độ chính xác của cây: SSR (sum of squared residuals) = tổng bình phương của hiệu giá trị thực tế với giá trị dự đoán
  $$SSR = \sum_{i = 1}^{n} (Y_i - \hat{Y}_i)^2$$
  - Ta lần lượt đánh giá độ chính xác của từng phần
  - Cuối cùng ta tính được tổng SSR 2 nhánh của cây
  - Lưu ý rằng tổng SSR hiện tại chỉ là 1 cây đầu tiên, ta phải tiếp tục thực hiện tính tổng SSR của các trường hợp khác và đánh giá tiếp để lấy trường hợp tối ưu nhất.
  - Ta tiếp tục đi tính trung bình 2 điểm tiếp theo trong bộ dữ liệu
  - Đường trung bình chia dữ liệu thành 2 phần, bên trái và bên phải. Ta tiến hành thực hiện tính giá trị trung bình của bên trái và bên phải, tính SSR của từng phần của tổng giá trị của SSR của cây
  - Quá trình này được lặp qua tất cả các điểm của data, với mỗi 1 ngưỡng (trung bình của 2 điểm) ta sẽ có được giá trị SSR của cây. Cuối cùng ta được 1 ngưỡng có SSR nhỏ nhất chính là ngưỡng tốt nhất của cây
  - Sau khi tìm được ngưỡng tốt nhất, ta được 2 nhánh của cây
  - Tiến hành thực hiện tìm ngưỡng tối ưu nhất đối với từng nhánh của cây tương tự như data ban đầu. Việc tìm ngưỡng ở đây sẽ áp dụng đối với từng nhánh của cây sau khi đã được tách
  - Quá trình lại tiếp tục lặp đi lặp lại đối với từng ngưỡng, từng nhánh của cây do ngưỡng phân tách
- Điểm dừng của vòng lặp:
  - Underfit: là hiện tượng mô hình Machine Learning hoặc Deep Learning không học được đủ kiến thức từ dữ liệu huấn luyện và không đạt được hiệu suất tốt trên cả tập huấn luyện và tập kiểm tra (high bias or low variance)
  - Good Fit: là nằm giữa Underfitting và Overfitting. Mô hình cho ra kết quả hợp lý với cả tập dữ liệu huấn luyện và các tập dữ liệu mới. Đây là mô hình lý tưởng mang được tính tổng quát và khớp được với nhiều dữ liệu mẫu và cả các dữ liệu mới.
  - Overfit: là mô hình rất hợp lý, rất khớp với tập huấn luyện nhưng khi đem ra dự đoán với dữ liệu mới thì lại không phù hợp. Nguyên nhân có thể do ta chưa đủ dữ liệu để đánh giá hoặc do mô hình của ta quá phức tạp. Mô hình bị quá phức tạp khi mà mô hình của ta sử dụng cả những nhiễu lớn trong tập dữ liệu để học, dấn tới mất tính tổng quát của mô hình (high variance or low bias). Nếu kết quả training quá tốt đạt tỷ lệ 100% thì cần phải xem xét lại dataset vì rất có thể ta đang mắc phải trường hợp overfitting.
  - Để tránh overfitting thông thường ta sẽ giới hạn tổng số node (observation) tối đa để thực hiện tách tiếp là từ 8-20
- Prunning và Tree complexity penalty:
  - Tree score là độ phức tạp của cây
$$Tree\  score = sum \ of \ squared \ residuals + \alpha T$$
$$\text{\\alpha : là hệ số tính toán }  $$
$$\text{T: là tổng số lá của cây}$$
- Cho $\alpha = 0$ thì ta được giá trị tree score nhỏ nhất
- Khi ta bỏ bớt nhánh của cây, ta sẽ tính tree score với α tăng dần sao cho giá trị tree score mới tốt hơn tree score ban đầu
- Tiếp tục bỏ bớt nhánh và tăng giá trị α, có bao nhiêu cây được bỏ nhánh thì có bấy nhiêu giá trị α được xác định
- Sử dụng K fold chia dữ liệu thành dữ liệu train và dữ liệu test, dữ liệu được phân tách thành các fold, ta phải đi xây dựng cây theo giá trị $\alpha$ đã được xác định ở trên. Mục đích chia dữ liệu để tăng sự đa dạng cho dữ liệu để quá trình huấn luyện được diễn ra tốt hơn
- Lập bảng giá trị, tính giá trị trung bình theo từng giá trị α và chọn giá tri $\alpha$ tốt nhất
