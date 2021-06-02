- Spring boot
	@get: lấy dữ liệu
	@post: thêm dữ liệu
	@put: sửa dữ liệu
	@delete: xóa dữ liệu
	@Controller: đánh dấu 1 component để điều khiển
	@RequestBody: được gắn ở tên biến, vì bây giờ chúng ta xây dựng API, nên các thông tin từ phía Client gửi lên Server sẽ nằm trong Body, và cũng dưới dạng JSON luôn
	@ResponseBody: trả về text thay vì view
	@RestController = @Controller+ @ResponseBody
	@PathVariable: chỉ ra là các tham số của phương thức này được đặt trong url template vaiable {} Basically
	ResponseEntity: nó đại diện cho toàn bộ HTTP response
	@RequestParam: lấy giá trị của @PathVariable
	@Qualifier: xác định bean, đặt tên giống với bean sẽ không cần đặt @Qualifier
	@Autowired: inject bean
	
	
- JPA
	@JsonIgnore
	@ManyToOne
	@JoinColumn
	@Column
	@EmbeddedId
	@AttributeOverrides
	@AttributeOverride
	@Entity
	@Table
	@Temporal
	JpaRepository<Object, Id>
	@Query
	
	
- Retrofit
	@Path: giống @PathVariable trong spring
	@Body: giống @RequestBody trong spring
	@Query: nối thêm  paramater vào sau URL
	@QueryMap: thêm nhiều tham số truy vấn
	@FormUrlEncoded: dữ liệu sẽ được mã hóa khi gửi yêu cầu
	@Field: các tham số dùng chung với @FormUrlEncoded
	@Multipart: nhiều yêu cầu
	@Part: dùng với @Multipart đối với các yêu cầu
	@Expose: chỉ ra rằng trường này nên được định nghĩa với JSON serialization hoặc deserialization.
	@SerializedName: để ánh xạ các khoá JSON với các trường dữ liệu.
