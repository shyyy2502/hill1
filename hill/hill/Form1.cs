using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hill
{
    public partial class Form1 : Form
    {
        // Bảng mã ký tự sử dụng trong Hill Cipher. Bao gồm các ký tự từ A-Z, a-z, các ký tự số và ký tự đặc biệt.
        private string hillAlphabet = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,0,1,2,3,4,5,6,7,8,9,.,,,?,!, ,@,#,$,%,^,&,*,-,+,(,),{,},[,],;,:";
        private List<char> hillCharList;// Danh sách chứa từng ký tự của hillAlphabet. Được sử dụng để ánh xạ ký tự và tìm chỉ số của chúng trong mã hóa/giải mã.

        public Form1()
        {
            InitializeComponent();
            // Tách từng ký tự trong hillAlphabet bằng dấu phẩy ',' và chuyển thành danh sách các ký tự.
            hillCharList = hillAlphabet
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries) // Loại bỏ các phần tử rỗng
                .Select(c => c[0]) // Lấy ký tự đầu tiên
                .ToList(); // Chuyển thành danh sách
        }

        // Hàm lấy ma trận từ input
        private int[,] GetKeyMatrix(int size)
        {
            // Tách chuỗi ma trận theo dòng
            string[] matrixRows = txt_Khoa.Text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int[,] keyMatrix = new int[size, size];// Tạo ma trận n x n
             // Lấy từng dòng trong ma trận
            for (int i = 0; i < size; i++)
            {
                // Tách các phần tử của từng dòng theo khoảng trắng hoặc dấu phẩy
                string[] rowValues = matrixRows[i].Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < size; j++)
                {
                    int value;
                    // Chuyển đổi giá trị chuỗi thành số nguyên và gán vào ma trận.
                    if (int.TryParse(rowValues[j], out value))
                    {
                        keyMatrix[i, j] = value;
                    }
                    else
                    {
                        // Nếu có giá trị không hợp lệ, báo lỗi và dừng chương trình.
                        MessageBox.Show("Giá trị không hợp lệ trong ma trận khóa!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //throw new FormatException("Input string was not in a correct format.");
                    }
                }
            }
            return keyMatrix;
        }

        // Mã hóa 
        private string EncryptHillCipher(string plainText, int[,] keyMatrix)
        {
            int n = keyMatrix.GetLength(0); // Lấy kích thước ma trận
          // Lấy chỉ số của từng ký tự trong bản rõ từ hillCharList
            List<int> plainTextIndexes = plainText.Select(c => hillCharList.IndexOf(c)).ToList();
            List<int> cipherTextIndexes = new List<int>();// Danh sách chứa chỉ số bản mã

            // Kiểm tra độ dài và thêm padding nếu cần(nếu độ dài bản rõ không chia hết cho kích thước ma trận)
            while (plainTextIndexes.Count % n != 0)
            {
                plainTextIndexes.Add(hillCharList.IndexOf(' ')); // Padding bằng dấu cách
            }

            // Xử lý mã hóa với các nhóm ký tự
            for (int i = 0; i < plainTextIndexes.Count; i += n)
            {
                int[] temp = new int[n];// Mảng tạm thời chứa kết quả của một khối
                for (int row = 0; row < n; row++)
                {
                    temp[row] = 0;
                    for (int col = 0; col < n; col++)
                    {
                        // Nhân ma trận khóa với bản rõ và lưu kết quả tạm thời
                        temp[row] += keyMatrix[row, col] * plainTextIndexes[i + col];
                    }
                    temp[row] %= hillCharList.Count; // modulo trên số lượng ký tự
                }
                // Thêm kết quả của khối vào danh sách bản mã
                cipherTextIndexes.AddRange(temp);
            }
            // Chuyển đổi các chỉ số thành chuỗi bản mã và trả về
            return new string(cipherTextIndexes.Select(index => hillCharList[index]).ToArray());
        }

        // Giải mã 
        private string DecryptHillCipher(string cipherText, int[,] inverseKeyMatrix)
        {
            int n = inverseKeyMatrix.GetLength(0);// Lấy kích thước ma trận
            // Lấy chỉ số của từng ký tự trong bản mã từ hillCharList
            List<int> cipherTextIndexes = cipherText.Select(c => hillCharList.IndexOf(c)).ToList();
            List<int> plainTextIndexes = new List<int>();// Danh sách chứa chỉ số bản rõ

            for (int i = 0; i < cipherTextIndexes.Count; i += n) // Xử lý giải mã theo từng khối kích thước n
            {
                int[] temp = new int[n];// Mảng tạm thời chứa kết quả của một khối
                for (int row = 0; row < n; row++)
                {
                    temp[row] = 0;
                    for (int col = 0; col < n; col++)
                    {
                        temp[row] += inverseKeyMatrix[row, col] * cipherTextIndexes[i + col]; // Nhân ma trận nghịch đảo với bản mã và lưu kết quả tạm thời
                    }
                    temp[row] %= hillCharList.Count;// Lấy phần dư để giữ kết quả trong phạm vi bảng mã
                }
                plainTextIndexes.AddRange(temp);// Thêm kết quả của khối vào danh sách bản rõ
            }
            // Chuyển đổi các chỉ số thành chuỗi bản rõ và trả về
            return new string(plainTextIndexes.Select(index => hillCharList[index]).ToArray());
        }

        private void btn_MaHoa_Click(object sender, EventArgs e)
        {
            try
            {
                string plainText = txt_BanRo.Text;

                // Lấy kích thước ma trận từ txt_L
                int size;
                if (!int.TryParse(txt_L.Text, out size))// Kiểm tra input kích thước
                {
                    MessageBox.Show("Vui lòng nhập kích thước ma trận hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra số phần tử cần thiết
                int requiredElements = size * size;
                string[] matrixElements = txt_Khoa.Text.Split(new[] { ' ', ',', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                if (matrixElements.Length != requiredElements)
                {
                    MessageBox.Show($"Bạn phải nhập {requiredElements} số cho ma trận khóa!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy ma trận khóa từ input
                int[,] keyMatrix = GetKeyMatrix(size);

                // Kiểm tra nếu độ dài của văn bản không chia hết cho kích thước ma trận thì thêm ký tự padding
                while (plainText.Length % size != 0)
                {
                    plainText += " "; // Padding thêm dấu cách nếu không chia hết
                }
                // Mã hóa và hiển thị kết quả
                string cipherText = EncryptHillCipher(plainText, keyMatrix);
                txt_BanMa.Text = cipherText;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mã hóa: " + ex.Message);
            }
        }

        private void btn_GiaiMa_Click(object sender, EventArgs e)
        {
            try
            {
                string cipherText = txt_BanMa.Text;

                // Lấy kích thước ma trận từ txt_L
                int size;
                if (!int.TryParse(txt_L.Text, out size))
                {
                    MessageBox.Show("Vui lòng nhập kích thước ma trận hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy ma trận khóa từ input
                int[,] keyMatrix = GetKeyMatrix(size);

                // Tính toán ma trận nghịch đảo cho ma trận lớn hơn 2x2
                int[,] inverseKeyMatrix = InverseMatrix(keyMatrix, size);
                // Giải mã và hiển thị kết quả
                string plainText = DecryptHillCipher(cipherText, inverseKeyMatrix);
                txt_BanRo.Text = plainText;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi giải mã: " + ex.Message);
            }
        }

        // Hàm tính nghịch đảo modulo (cho định thức)
        private int ModInverse(int a, int mod)
        {
            a = a % mod;
            for (int x = 1; x < mod; x++)
            {
                if ((a * x) % mod == 1)
                    return x;
            }
            throw new Exception("Không tìm thấy nghịch đảo modulo.");
        }

        // Hàm tính định thức của ma trận n x n
        private int Determinant(int[,] matrix, int n)
        {
            int det = 0;
            if (n == 1)
                return matrix[0, 0];// Trường hợp ma trận 1x1

            int[,] temp = new int[n, n];// Ma trận con
            int sign = 1;

            for (int f = 0; f < n; f++)
            {// Tính ma trận con và tính định thức đệ quy
                GetCofactor(matrix, temp, 0, f, n);
                det += sign * matrix[0, f] * Determinant(temp, n - 1); // Công thức đệ quy định thức
                sign = -sign;// Thay đổi dấu
            }

            return det;
        }

        // Hàm lấy ma trận con để tính định thức
        private void GetCofactor(int[,] matrix, int[,] temp, int p, int q, int n)
        {
            int i = 0, j = 0;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (row != p && col != q)// Bỏ qua hàng và cột cần loại bỏ
                    {
                        temp[i, j++] = matrix[row, col];// Sao chép phần còn lại vào ma trận con

                        if (j == n - 1)// Khi hết cột, chuyển sang hàng tiếp theo
                        {
                            j = 0;
                            i++;
                        }
                    }
                }
            }
        }

        // Hàm tính ma trận nghịch đảo n x n
        private int[,] InverseMatrix(int[,] matrix, int n)
        {
            int det = Determinant(matrix, n);// Tính định thức
            if (det == 0)
            {
                throw new Exception("Ma trận không khả nghịch."); // Nếu định thức = 0, không có ma trận nghịch đảo
            }

            int detInv = ModInverse(det, hillCharList.Count);  // Nghịch đảo modulo của định thức
            int[,] adj = new int[n, n];
            int[,] inv = new int[n, n];

            // Tính ma trận adjoint
            Adjoint(matrix, adj, n);

            // Tính ma trận nghịch đảo  từ adjoint và định thức
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    inv[i, j] = adj[i, j] * detInv % hillCharList.Count;
                    if (inv[i, j] < 0)
                        inv[i, j] += hillCharList.Count;
                }
            }
            return inv;
        }

        // Hàm tính ma trận adjoint của ma trận n x n
        private void Adjoint(int[,] matrix, int[,] adj, int n)
        {
            if (n == 1)
            {
                adj[0, 0] = 1;// Trường hợp ma trận 1x1
                return;
            }

            int sign = 1;
            int[,] temp = new int[n, n];
            // Tính ma trận adjoint
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    GetCofactor(matrix, temp, i, j, n);// Lấy ma trận con
                    sign = ((i + j) % 2 == 0) ? 1 : -1; // Xác định dấu
                    adj[j, i] = (sign * Determinant(temp, n - 1)) % hillCharList.Count;

                    if (adj[j, i] < 0)
                        adj[j, i] += hillCharList.Count; // Điều chỉnh giá trị về trong phạm vi bảng mã
                }
            }
        }
    }
}
