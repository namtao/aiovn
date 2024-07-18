# DEEP LEARNING - IAN GOODFELLOW AND YOSHUA BENGIO AND AARON COURVILLE

- [DEEP LEARNING - IAN GOODFELLOW AND YOSHUA BENGIO AND AARON COURVILLE](#deep-learning---ian-goodfellow-and-yoshua-bengio-and-aaron-courville)
  - [Chương 01: Giới thiệu](#chương-01-giới-thiệu)
    - [Nội dung chính](#nội-dung-chính)
  - [Chương 2: Đại số tuyến tính](#chương-2-đại-số-tuyến-tính)
    - [Scalars (Số vô hướng), Vectors, Matrices (Ma trận) and Tensors](#scalars-số-vô-hướng-vectors-matrices-ma-trận-and-tensors)
    - [Nhân ma trận với vector](#nhân-ma-trận-với-vector)
    - [Ma trận đơn vị và ma trận nghịch đảo](#ma-trận-đơn-vị-và-ma-trận-nghịch-đảo)
    - [Phụ thuộc tuyến tính và không gian con](#phụ-thuộc-tuyến-tính-và-không-gian-con)
    - [Norms (Chuẩn của vecto)](#norms-chuẩn-của-vecto)
    - [Các loại ma trận và vecto đặc biệt](#các-loại-ma-trận-và-vecto-đặc-biệt)
    - [Phân tích Eigen](#phân-tích-eigen)
    - [Phân tích Giá trị Kỳ dị](#phân-tích-giá-trị-kỳ-dị)
    - [Toán tử Trace](#toán-tử-trace)
    - [Định thức (Determinant)](#định-thức-determinant)
    - [Principal Components Analysis (PCA)](#principal-components-analysis-pca)
  - [Chương 3: Xác suất và lý tuyết thông tin](#chương-3-xác-suất-và-lý-tuyết-thông-tin)

## Chương 01: Giới thiệu

> Chương này giới thiệu deep learning như một giải pháp cho thách thức giải quyết các nhiệm vụ dễ dàng đối với con người nhưng khó để máy tính mô tả theo cách hình thức. Nó giải thích làm thế nào deep learning cho phép máy tính học các khái niệm phức tạp từ dữ liệu bằng cách xây dựng chúng từ những khái niệm đơn giản hơn. Chương cũng bàn về các hạn chế của các phương pháp AI truyền thống, như hệ thống dựa trên tri thức, và nhấn mạnh sự quan trọng của học biểu diễn trong deep learning. Nó kết thúc bằng việc cung cấp một tổng quan về cấu trúc của cuốn sách và sự phát triển lịch sử của deep learning.

### Nội dung chính

- Deep learning là một kỹ thuật cho phép máy tính học từ kinh nghiệm và hiểu thế giới thông qua một hệ thống các khái niệm cấp cao.
Các phương pháp AI truyền thống, như các hệ thống dựa trên tri thức, gặp khó khăn trong các nhiệm vụ mà con người tìm hiểu một cách tự nhiên nhưng lại khó để mô tả hình thức.
- Deep learning vượt qua điều này bằng cách học các biểu diễn từ dữ liệu, cho phép máy tính hiểu thế giới mà không cần lập trình rõ ràng.
Học biểu diễn là yếu tố quan trọng để thành công của deep learning, vì nó cho phép máy tính khám phá các đặc trưng có ý nghĩa từ dữ liệu thô.
- Các yếu tố biến đổi, là các yếu tố không được quan sát trực tiếp trên dữ liệu, là rất quan trọng để deep learning có thể giải thích sự biến động đa dạng trong dữ liệu.

## Chương 2: Đại số tuyến tính

> Chương này giới thiệu các khái niệm cơ bản của đại số tuyến tính, bao gồm vector, ma trận, phép nhân ma trận, phép nhân vector và ma trận, và các phép toán hữu ích khác. Chương cũng bàn về các hàm mất mát và gradient descent, một phương pháp tối ưu hóa phổ biến trong deep learning. Chương kết thúc bằng việc giới thiệu các khái niệm nâng cao hơn, bao gồm các phép nhân ma trận hiệu quả hơn, các phép toán trên ma trận và vector, và các phép toán trên tensor. Chương cung cấp một nền tảng vững chắc cho các chương tiếp theo, trong đó sẽ sử dụng các khái niệm và kỹ thuật đại số tuyến tính để xây dựng và huấn luyện các mô hình deep learning.

### Scalars (Số vô hướng), Vectors, Matrices (Ma trận) and Tensors

| Đối tượng   | Định nghĩa                       | Quan hệ với đối tượng khác                            |
|-------------|-----------------------------------|-------------------------------------------------------|
| Scalars     | Một số đơn lẻ                      | Thành phần cơ bản của tất cả các đối tượng khác       |
| Vectors     | Mảng một chiều các số vô hướng     | Một tập hợp các số vô hướng                           |
| Matrices    | Mảng hai chiều các số              | Một tập hợp các véc-tơ, các phần tử là số vô hướng    |
| Tensors     | Mảng nhiều chiều các số            | Một tập hợp các ma trận, các phần tử có thể là số vô hướng, véc-tơ hoặc ma trận |

Vector và ma trận có thể thực hiện các phép toán với nhau, miễn là chúng có cùng hình dạnh hoặc các chiều chỉ có 1 phần tử (broadcasting)

### Nhân ma trận với vector

**Điều kiện**: Số cột của $A$ phải có cùng số hàng của $B$. Nếu $A$ có kích thước $m \times n$ và $B$ có kích thước $n \times p$, thì $C$ có kích thước $m \times p$

$$ C_{i,j} = \sum_{k} A_{i,k}B_{k,j} $$

Tích giữa các phần tử trong vector gọi là *Tích Hadamard* hay *Element-wise*, ký hiệu $A \circ B$

**Tích vô hướng** giữa hai vector $x$ và $y$ có cùng kích thước là tích ma trận $x^T y$. Ta có thể coi tích ma trận $C = AB$ như việc tính $C_{i,j}$ là tích vô hướng giữa hàng $i$ của $A$ và cột $j$ của $B$.

### Ma trận đơn vị và ma trận nghịch đảo

**Ma trận đơn vị**: là ma trận mà tất cả các phần tử trên đường chéo chính đều là 1, trong khi tất cả các phần tử khác đều là 0

**Ma trận nghịch đảo**  của $A$ được ký hiệu là $A^{-1}$, và nó được định nghĩa là ma trận sao cho $A^{-1} A = I_n$

### Phụ thuộc tuyến tính và không gian con

*Phụ thuộc tuyến tính*: một tập hợp các vector được gọi là phụ thuộc tuyến tính nếu ít nhất một vector trong tập hợp có thể biểu diễn như là tổ hợp tuyến tính của các vector khác trong tập hợp đó.

> Ví dụ: Xem xét các vector $\mathbf{v}_1 = (1, 2)$ và $\mathbf{v}_2 = (2, 4)$. Ở đây, $\mathbf{v}_2 = 2 \mathbf{v}_1$, nghĩa là $\mathbf{v}_2$ phụ thuộc tuyến tính vào $\mathbf{v}_1$.

*Độc lập tuyến tính*: là không có vector nào trong tập hợp có thể biểu diễn như là tổ hợp tuyến tính của các vector khác.

*Không gian con* của một tập hợp các vector là tập hợp tất cả các điểm có thể đạt được bằng cách tổ hợp tuyến tính của các vector đó. Ví dụ, nếu bạn có hai vector trong không gian 2D, không gian con của chúng là tất cả các điểm trên mặt phẳng được tạo bởi hai vector đó.

> Ví dụ: Nếu chúng ta có các vector $\mathbf{v}_1 = (1, 0)$ và $\mathbf{v}_2 = (0, 1)$, không gian con của chúng là toàn bộ mặt phẳng 2D $\mathbb{R}^2$, vì chúng ta có thể biểu diễn mọi điểm trong mặt phẳng này bằng tổ hợp tuyến tính của $\mathbf{v}_1$ và $\mathbf{v}_2$.

*Không gian cột* của một ma trận là không gian con được tạo bởi các cột của ma trận đó. Để phương trình $Ax = b$ có nghiệm, $b$ phải nằm trong không gian cột của $A$. Để không gian cột bao trùm toàn bộ $\mathbb{R}^m$, ma trận $A$ phải có ít nhất $m$ cột và các cột này phải độc lập tuyến tính.

*Ma trận vuông* là ma trận có số hàng bằng số cột (m = n). Ma trận vuông với các cột phụ thuộc tuyến tính được gọi là *Ma trận suy biến*, không có nghịch đảo.

*Nghịch đảo ma trận (Matrix Inverse)*: Ma trận nghịch đảo của $A$ là ma trận $A^{-1}$ sao cho $A^{-1} A = I_n$, với $I_n$ là ma trận đơn vị. Nếu $A$ không phải là ma trận vuông hoặc là ma trận vuông nhưng suy biến, không thể sử dụng nghịch đảo ma trận để giải phương trình.

*Nghịch đảo trái và phải (Left and Right Inverse)*: Nghịch đảo trái và nghịch đảo phải của ma trận vuông là như nhau. Công thức nghịch đảo phải: $AA^{-1} = I$.

*Tổ hợp tuyến tính*: của một tập hợp các vector là sự kết hợp của các vector đó với các hệ số vô hướng.

> Ví dụ: Với các vector $\mathbf{v}_1 = (1, 2)$ và $\mathbf{v}_2 = (3, 4)$, tổ hợp tuyến tính có thể là $2\mathbf{v}_1 + 3\mathbf{v}_2 = 2(1, 2) + 3(3, 4) = (2, 4) + (9, 12) = (11, 16)$.

### Norms (Chuẩn của vecto)

Norms là một hàm đo kích thước của vector, ánh xạ các vector tới các giá trị không âm

### Các loại ma trận và vecto đặc biệt

*Ma trận chéo*: Ma trận chủ yếu gồm các số không và chỉ có các phần tử khác không trên đường chéo chính

*Ma trận đối xứng*: Các phần tử được tạo ra bởi một hàm của hai đối số không phụ thuộc vào thứ tự của các đối số

### Phân tích Eigen

*Eigen* Là quá trình phân tách một ma trận thành các eigenvector và eigenvalue của nó. Giúp ta hiểu rõ hơn về các tính chất của ma trận mà không rõ ràng từ cách biểu diễn ma trận như một mảng các phần tử.

*Eigenvalues* và *Eigenvectors* là các giá trị và vector đặc biệt của ma trận. Eigenvalues là các giá trị thực mà khi nhân với một eigenvector, kết quả vẫn là một vector tương ứng với eigenvector đó. Phương trình tìm eigenvalues và eigenvectors là $A\mathbf{v} = \lambda\mathbf{v}$. Để tìm eigenvalues, ta giải phương trình đặc trưng $|A - \lambda I| = 0$. Sau khi tìm được eigenvalues, ta tìm eigenvectors bằng cách giải hệ phương trình $(A - \lambda I)\mathbf{v} = \mathbf{0}$.

Phân tích Eigen: Giúp hiểu rõ các tính chất của ma trận, tương tự như việc phân tích một số nguyên thành các thừa số nguyên tố giúp ta hiểu rõ hành vi của số đó. Phân tích eigen của một ma trận thực đối xứng có thể dùng để tối ưu hóa các biểu thức bậc hai.

### Phân tích Giá trị Kỳ dị

### Toán tử Trace

Toán tử Trace cho ta tổng của tất cả các phần tử trên đường chéo chính của một ma trận

### Định thức (Determinant)

Định thức của một ma trận vuông là một số thực được tính bằng cách lấy tổng của tích các phần tử trên mỗi hàng (hoặc cột) của ma trận, với dấu của mỗi tích phụ thuộc vào vị trí của phần tử trong ma trận. Định thức của một ma trận vuông $A$ được ký hiệu là $|A|$ hoặc $det(A)$. Định thức của một ma trận vuông $A$ được tính bằng công thức sau: $|A| = \sum_{\sigma \in S_n} \text{sgn}(\sigma) \prod_{i=1}^n a_{i, \sigma(i)}$, trong đó $S_n$ là tập hợp tất cả các hoán vị của $n$ phần tử, $\text{sgn}(\sigma)$ là dấu của hoán vị $\sigma$, $a_{i, \sigma(i)}$ là phần tử thứ $i$ trên hàng $i$ của ma trận $A$ sau khi được hoán vị theo $\sigma$.

**Ý nghĩa của Định thức:**

- Giá trị tuyệt đối của định thức đo lường mức độ mà phép nhân bởi ma trận đó làm giãn nở hoặc thu nhỏ không gian.
- Nếu định thức bằng 0, không gian bị thu nhỏ hoàn toàn theo ít nhất một chiều, làm cho nó mất toàn bộ thể tích.
- Nếu định thức bằng 1, phép biến đổi giữ nguyên thể tích.

### Principal Components Analysis (PCA)

PCA là một kỹ thuật thống kê được sử dụng để giảm số chiều dữ liệu mà vẫn giữ lại được thông tin quan trọng nhất. PCA tìm ra các thành phần chính (principal components) của dữ liệu, mà các thành phần chính này là các vector hướng mới trong không gian chiều thấp hơn, sao cho dữ liệu được biểu diễn trên các vector hướng này có phương sai lớn nhất. Các thành phần chính được tính bằng cách phân tích eigenvalues và eigenvectors của ma trận hiệp phương sai của dữ liệu.

## Chương 3: Xác suất và lý tuyết thông tin
