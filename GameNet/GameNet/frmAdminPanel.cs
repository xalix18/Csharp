using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GameNet
{
    public partial class frmAdminPanel : Form
    {
        public frmAdminPanel()
        {
            InitializeComponent();
        }
        //توابع
        // تعریف متغیرها برای ذخیره مقادیر انتخاب شده از کامبوباکس‌ها
        public string radcontrollervalue;
        public string sysnumcombovalue;

        string connectionString = "Data Source=(localdb)\\localhost;Initial Catalog=GAMENET;Integrated Security=True";

        private bool displayData5()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open(); // اتصال به دیتابیس

                    string query = "SELECT id AS 'شماره سیستم',controllerNumber AS 'تعداد دسته',startTime AS 'زمان شروع',endTime AS 'زمان پایان',price AS 'مبلغ' FROM dataGridView5"; // نام جدول خود را به جای 'YourTable' وارد کنید
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    dataAdapter.Fill(dataTable); // داده‌ها را به DataTable وارد می‌کند

                    // نمایش داده‌ها در DataGridView
                    dgv_5.DataSource = dataTable;

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }
        }

        private bool displayData4()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open(); // اتصال به دیتابیس

                    string query = "SELECT id AS 'شماره سیستم',controllerNumber AS 'تعداد دسته',startTime AS 'زمان شروع',endTime AS 'زمان پایان',price AS 'مبلغ' FROM dataGridView4"; // نام جدول خود را به جای 'YourTable' وارد کنید
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    dataAdapter.Fill(dataTable); // داده‌ها را به DataTable وارد می‌کند

                    // نمایش داده‌ها در DataGridView
                    dgv_4.DataSource = dataTable;

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false;
                }
            }
        }













        // این متد آیتم‌ها را به کامبوباکس‌ها اضافه می‌کند
        private void AddSyscomboItem()
        {
            // حلقه برای اضافه کردن مقادیر به کامبوباکس‌ها
            for (int i = 0; i <= 10; i++)
            {
                if (i == 0) // برای اولین آیتم (مقدار پیش‌فرض)
                {
                    // اضافه کردن "انتخاب کنید" به کامبوباکس‌ها و تنظیم مقدار پیش‌فرض
                    sysnum_combo4.Items.Add("انتخاب کنید");
                    sysnum_combo4.Text = "انتخاب کنید";
                    sysnum_combo5.Items.Add("انتخاب کنید");
                    sysnum_combo5.Text = "انتخاب کنید";
                }
                else // برای مقادیر دیگر (عددهای 1 تا 10)
                {
                    // اضافه کردن اعداد به کامبوباکس‌ها
                    sysnum_combo4.Items.Add(i);
                    sysnum_combo5.Items.Add(i);
                    
                }
            }
        }

        // این متد وضعیت انتخاب آیتم‌ها را بررسی می‌کند و رابط کاربری را فعال یا غیرفعال می‌کند
        private void CheckSelectedItem_ComboSysNum()
        {
            // بررسی اینکه آیا تعداد آیتم‌ها در کامبوباکس‌ها به 11 رسیده است
            if (sysnum_combo5.Items.Count == 11 && sysnum_combo4.Items.Count == 11)
            {
                // بر اساس تب انتخاب شده در کنترل TabControl رفتارهای مختلف انجام می‌دهیم
                switch (tabControl1.SelectedTab.Name)
                {
                    case "tabPage1": // در صورت انتخاب تب اول
                        if (sysnum_combo5.SelectedItem.ToString() != "انتخاب کنید") // اگر آیتم انتخاب شده متفاوت از "انتخاب کنید" باشد
                        {
                            controller_grp5.Enabled = true; // فعال کردن گروه کنترلر
                        }
                        else
                        {
                            controller_grp5.Enabled = false; // غیرفعال کردن گروه کنترلر
                            cost_grp5.Enabled = false; // غیرفعال کردن گروه هزینه
                        }
                        break;
                    case "tabPage2": // در صورت انتخاب تب دوم
                        if (sysnum_combo4.SelectedItem.ToString() != "انتخاب کنید") // اگر آیتم انتخاب شده متفاوت از "انتخاب کنید" باشد
                        {
                            controller_grp4.Enabled = true; // فعال کردن گروه کنترلر
                        }
                        else
                        {
                            controller_grp4.Enabled = false; // غیرفعال کردن گروه کنترلر
                            cost_grp4.Enabled = false; // غیرفعال کردن گروه هزینه
                        }
                        break;

                }
            }
        }



        private void addDataRow()
        {
            var categoryValues = new Dictionary<string, int>
    {
        { "تک دسته", 1 },
        { "دو دسته", 2 },
        { "سه دسته", 3 },
        { "چهار دسته", 4 }
    };

            switch (tabControl1.SelectedTab.Name)
            {
                case "tabPage1":

                    if (sysnum_combo5.SelectedItem.ToString() != "انتخاب کنید")
                    {
                        sysnumcombovalue = sysnum_combo5.SelectedItem.ToString();
                        foreach (Control control in controller_grp5.Controls)
                        {
                            if (control is RadioButton radioButton && radioButton.Checked)
                            {
                                radcontrollervalue = radioButton.Text;
                                break; // Exit the loop after finding the checked radio button
                            }
                        }
                        if (radcontrollervalue.Length > 0)
                        {
                            foreach (Control control in cost_grp5.Controls)
                            {
                                if (control is RadioButton radioButton && radioButton.Checked)
                                {
                                    switch (radioButton.Name)
                                    {
                                        case "rad_csttime5":
                                            if (txb_csttime5.Text.Length > 0)
                                            {
                                                if (categoryValues.TryGetValue(radcontrollervalue, out int radcontrollervalueASnum))
                                                {
                                                    int additionalMinutes = 0;
                                                    if (!int.TryParse(txb_csttime5.Text, out additionalMinutes))
                                                    {
                                                        MessageBox.Show("مقدار دقیقه‌ها صحیح نیست");
                                                        return;
                                                    }

                                                    using (SqlConnection connection = new SqlConnection(connectionString))
                                                    {
                                                        try
                                                        {
                                                            connection.Open();

                                                            // کوئری برای بررسی وجود شماره سیستم در دیتابیس
                                                            string checkQuery = "SELECT COUNT(*) FROM dataGridView5 WHERE id = @id";
                                                            using (SqlCommand cmdCheck = new SqlCommand(checkQuery, connection))
                                                            {
                                                                cmdCheck.Parameters.AddWithValue("@id", sysnumcombovalue);

                                                                // چک کردن تعداد ردیف‌ها
                                                                int count = (int)cmdCheck.ExecuteScalar();
                                                                if (count > 0)
                                                                {
                                                                    MessageBox.Show("این شماره سیستم قبلاً وارد شده است.");
                                                                    return; // اگر شماره سیستم قبلاً موجود باشد، عملیات متوقف می‌شود
                                                                }
                                                            }

                                                            // اگر شماره سیستم جدید باشد، ادامه عملیات
                                                            string query = "INSERT INTO dataGridView5 (id, controllerNumber, startTime, endTime, price) " +
                                                                           "VALUES (@id, @controllerNumber, @startTime, @endTime, @price)";

                                                            using (SqlCommand cmd = new SqlCommand(query, connection))
                                                            {
                                                                // پارامترها
                                                                cmd.Parameters.AddWithValue("@id", sysnumcombovalue);
                                                                cmd.Parameters.AddWithValue("@controllerNumber", radcontrollervalueASnum);

                                                                // دریافت زمان شروع (startTime) به صورت DateTime
                                                                DateTime startTime = DateTime.Now; // ساعت و دقیقه فعلی
                                                                cmd.Parameters.AddWithValue("@startTime", startTime);

                                                                // محاسبه زمان پایان (endTime) با اضافه کردن دقیقه‌ها
                                                                DateTime endTime = startTime.AddMinutes(additionalMinutes);
                                                                cmd.Parameters.AddWithValue("@endTime", endTime);

                                                                // گرفتن قیمت از دیتابیس
                                                                string queryPrice = "SELECT price FROM priceTB WHERE controllerNumber=@controllerNumber AND systemtype='PS5'";
                                                                decimal price = 0;

                                                                using (SqlCommand cmmd = new SqlCommand(queryPrice, connection))
                                                                {
                                                                    cmmd.Parameters.AddWithValue("@controllerNumber", radcontrollervalueASnum);
                                                                    var result = cmmd.ExecuteScalar();
                                                                    if (result != null)
                                                                    {
                                                                        price = (decimal)result;
                                                                    }
                                                                    else
                                                                    {
                                                                        MessageBox.Show("Price not found for the given controller number.");
                                                                        return;
                                                                    }
                                                                }
                                                                price *= 60;
                                                                // محاسبه قیمت نهایی
                                                                decimal totalPrice = Math.Round(additionalMinutes * price, 2);
                                                                cmd.Parameters.AddWithValue("@price", totalPrice);

                                                                // اجرای کوئری
                                                                int rowsAffected = cmd.ExecuteNonQuery();

                                                                if (rowsAffected > 0)
                                                                {
                                                                    displayData5();
                                                                    sysnumcombovalue = "";
                                                                    radcontrollervalue = "";
                                                                    return;
                                                                }
                                                                else
                                                                {
                                                                    MessageBox.Show("Failed to add the record.");
                                                                }
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            MessageBox.Show("Error: " + ex.Message);
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("زمان مد نظر را وارد کنید");
                                            }
                                            break;

                                        case "rad_cstmoney5":
                                            if (txb_cstmoney5.Text.Length > 0)
                                            {
                                                if (categoryValues.TryGetValue(radcontrollervalue, out int radcontrollervalueASnum))
                                                {
                                                    int additionalMoney = 0;
                                                    if (!int.TryParse(txb_cstmoney5.Text, out additionalMoney))
                                                    {
                                                        MessageBox.Show("مقدار مبلغ صحیح نیست");
                                                        return;
                                                    }

                                                    using (SqlConnection connection = new SqlConnection(connectionString))
                                                    {
                                                        try
                                                        {
                                                            connection.Open();

                                                            // کوئری برای بررسی وجود شماره سیستم در دیتابیس
                                                            string checkQuery = "SELECT COUNT(*) FROM dataGridView5 WHERE id = @id";
                                                            using (SqlCommand cmdCheck = new SqlCommand(checkQuery, connection))
                                                            {
                                                                cmdCheck.Parameters.AddWithValue("@id", sysnumcombovalue);

                                                                // چک کردن تعداد ردیف‌ها
                                                                int count = (int)cmdCheck.ExecuteScalar();
                                                                if (count > 0)
                                                                {
                                                                    MessageBox.Show("این شماره سیستم قبلاً وارد شده است.");
                                                                    return; // اگر شماره سیستم قبلاً موجود باشد، عملیات متوقف می‌شود
                                                                }
                                                            }
                                                            // اگر شماره سیستم جدید باشد، ادامه عملیات
                                                            string query = "INSERT INTO dataGridView5 (id, controllerNumber,price,startTime, endTime ) " +
                                                                           "VALUES (@id, @controllerNumber, @price, @startTime, @endTime)";
                                                            using (SqlCommand cmd = new SqlCommand(query, connection))
                                                            {
                                                                // پارامترها
                                                                cmd.Parameters.AddWithValue("@id", sysnumcombovalue);
                                                                cmd.Parameters.AddWithValue("@controllerNumber", radcontrollervalueASnum);

                                                                // گرفتن قیمت از دیتابیس
                                                                string queryPrice = "SELECT price FROM priceTB WHERE controllerNumber=@controllerNumber AND systemtype='PS5'";
                                                                decimal price = 0;

                                                                using (SqlCommand cmmd = new SqlCommand(queryPrice, connection))
                                                                {
                                                                    cmmd.Parameters.AddWithValue("@controllerNumber", radcontrollervalueASnum);
                                                                    var result = cmmd.ExecuteScalar();
                                                                    if (result != null)
                                                                    {
                                                                        price = (decimal)result;
                                                                    }
                                                                    else
                                                                    {
                                                                        MessageBox.Show("Price not found for the given controller number.");
                                                                        return;
                                                                    }
                                                                }
                                                                // دریافت مبلغ ورودی کاربر (مبلغ تایم)
                                                                decimal userAmount = 0;
                                                                if (!decimal.TryParse(txb_cstmoney5.Text, out userAmount))
                                                                {
                                                                    MessageBox.Show("مقدار وارد شده صحیح نیست.");
                                                                    return;
                                                                }

                                                                // تقسیم مبلغ ورودی بر قیمت
                                                                decimal resultInSeconds = userAmount / price;

                                                                // تبدیل از ثانیه به دقیقه
                                                                decimal resultInMinutes = resultInSeconds / 60;


                                                                cmd.Parameters.AddWithValue("@price", userAmount);


                                                                // دریافت زمان شروع (startTime) به صورت DateTime
                                                                DateTime startTime = DateTime.Now;  // ساعت و دقیقه فعلی
                                                                cmd.Parameters.AddWithValue("@startTime", startTime);

                                                                // محاسبه زمان پایان (endTime) با اضافه کردن دقیقه‌ها (از resultInMinutes)
                                                                DateTime endTime = startTime.AddMinutes((double)resultInMinutes); // نتیجه از ثانیه به دقیقه تبدیل شده
                                                                cmd.Parameters.AddWithValue("@endTime", endTime);



                                                                // اجرای کوئری
                                                                int rowsAffected = cmd.ExecuteNonQuery();

                                                                if (rowsAffected > 0)
                                                                {
                                                                    displayData5();
                                                                    sysnumcombovalue = "";
                                                                    radcontrollervalue = "";
                                                                    return;
                                                                }
                                                                else
                                                                {
                                                                    MessageBox.Show("Failed to add the record.");
                                                                }
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            MessageBox.Show("Error: " + ex.Message);
                                                        }

                                                    }
                                                }
                                            }
                                            break;
                                    }
                                }
                            }
                        }

                    }
                    break;






                case "tabPage2":

                    if (sysnum_combo4.SelectedItem.ToString() != "انتخاب کنید")
                    {
                        sysnumcombovalue = sysnum_combo4.SelectedItem.ToString();
                        foreach (Control control in controller_grp4.Controls)
                        {
                            if (control is RadioButton radioButton && radioButton.Checked)
                            {
                                radcontrollervalue = radioButton.Text;
                                break; // Exit the loop after finding the checked radio button
                            }
                        }
                        if (radcontrollervalue.Length > 0)
                        {
                            foreach (Control control in cost_grp4.Controls)
                            {
                                if (control is RadioButton radioButton && radioButton.Checked)
                                {
                                    switch (radioButton.Name)
                                    {
                                        case "rad_csttime4":
                                            if (txb_csttime4.Text.Length > 0)
                                            {
                                                if (categoryValues.TryGetValue(radcontrollervalue, out int radcontrollervalueASnum))
                                                {
                                                    int additionalMinutes = 0;
                                                    if (!int.TryParse(txb_csttime4.Text, out additionalMinutes))
                                                    {
                                                        MessageBox.Show("مقدار دقیقه‌ها صحیح نیست");
                                                        return;
                                                    }

                                                    using (SqlConnection connection = new SqlConnection(connectionString))
                                                    {
                                                        try
                                                        {
                                                            connection.Open();

                                                            // کوئری برای بررسی وجود شماره سیستم در دیتابیس
                                                            string checkQuery = "SELECT COUNT(*) FROM dataGridView4 WHERE id = @id";
                                                            using (SqlCommand cmdCheck = new SqlCommand(checkQuery, connection))
                                                            {
                                                                cmdCheck.Parameters.AddWithValue("@id", sysnumcombovalue);

                                                                // چک کردن تعداد ردیف‌ها
                                                                int count = (int)cmdCheck.ExecuteScalar();
                                                                if (count > 0)
                                                                {
                                                                    MessageBox.Show("این شماره سیستم قبلاً وارد شده است.");
                                                                    return; // اگر شماره سیستم قبلاً موجود باشد، عملیات متوقف می‌شود
                                                                }
                                                            }

                                                            // اگر شماره سیستم جدید باشد، ادامه عملیات
                                                            string query = "INSERT INTO dataGridView4 (id, controllerNumber, startTime, endTime, price) " +
                                                                           "VALUES (@id, @controllerNumber, @startTime, @endTime, @price)";

                                                            using (SqlCommand cmd = new SqlCommand(query, connection))
                                                            {
                                                                // پارامترها
                                                                cmd.Parameters.AddWithValue("@id", sysnumcombovalue);
                                                                cmd.Parameters.AddWithValue("@controllerNumber", radcontrollervalueASnum);

                                                                // دریافت زمان شروع (startTime) به صورت DateTime
                                                                DateTime startTime = DateTime.Now; // ساعت و دقیقه فعلی
                                                                cmd.Parameters.AddWithValue("@startTime", startTime);

                                                                // محاسبه زمان پایان (endTime) با اضافه کردن دقیقه‌ها
                                                                DateTime endTime = startTime.AddMinutes(additionalMinutes);
                                                                cmd.Parameters.AddWithValue("@endTime", endTime);

                                                                // گرفتن قیمت از دیتابیس
                                                                string queryPrice = "SELECT price FROM priceTB WHERE controllerNumber=@controllerNumber AND systemtype='PS4'";
                                                                decimal price = 0;

                                                                using (SqlCommand cmmd = new SqlCommand(queryPrice, connection))
                                                                {
                                                                    cmmd.Parameters.AddWithValue("@controllerNumber", radcontrollervalueASnum);
                                                                    var result = cmmd.ExecuteScalar();
                                                                    if (result != null)
                                                                    {
                                                                        price = (decimal)result;
                                                                    }
                                                                    else
                                                                    {
                                                                        MessageBox.Show("Price not found for the given controller number.");
                                                                        return;
                                                                    }
                                                                }
                                                                price *= 60;
                                                                // محاسبه قیمت نهایی
                                                                decimal totalPrice = Math.Round(additionalMinutes * price, 2);
                                                                cmd.Parameters.AddWithValue("@price", totalPrice);

                                                                // اجرای کوئری
                                                                int rowsAffected = cmd.ExecuteNonQuery();

                                                                if (rowsAffected > 0)
                                                                {
                                                                    displayData4();
                                                                    sysnumcombovalue = "";
                                                                    radcontrollervalue = "";
                                                                    return;
                                                                }
                                                                else
                                                                {
                                                                    MessageBox.Show("Failed to add the record.");
                                                                }
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            MessageBox.Show("Error: " + ex.Message);
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("زمان مد نظر را وارد کنید");
                                            }
                                            break;

                                        case "rad_cstmoney4":
                                            if (txb_cstmoney4.Text.Length > 0)
                                            {
                                                if (categoryValues.TryGetValue(radcontrollervalue, out int radcontrollervalueASnum))
                                                {
                                                    int additionalMoney = 0;
                                                    if (!int.TryParse(txb_cstmoney4.Text, out additionalMoney))
                                                    {
                                                        MessageBox.Show("مقدار مبلغ صحیح نیست");
                                                        return;
                                                    }

                                                    using (SqlConnection connection = new SqlConnection(connectionString))
                                                    {
                                                        try
                                                        {
                                                            connection.Open();

                                                            // کوئری برای بررسی وجود شماره سیستم در دیتابیس
                                                            string checkQuery = "SELECT COUNT(*) FROM dataGridView4 WHERE id = @id";
                                                            using (SqlCommand cmdCheck = new SqlCommand(checkQuery, connection))
                                                            {
                                                                cmdCheck.Parameters.AddWithValue("@id", sysnumcombovalue);

                                                                // چک کردن تعداد ردیف‌ها
                                                                int count = (int)cmdCheck.ExecuteScalar();
                                                                if (count > 0)
                                                                {
                                                                    MessageBox.Show("این شماره سیستم قبلاً وارد شده است.");
                                                                    return; // اگر شماره سیستم قبلاً موجود باشد، عملیات متوقف می‌شود
                                                                }
                                                            }
                                                            // اگر شماره سیستم جدید باشد، ادامه عملیات
                                                            string query = "INSERT INTO dataGridView4 (id, controllerNumber,price,startTime, endTime ) " +
                                                                           "VALUES (@id, @controllerNumber, @price, @startTime, @endTime)";
                                                            using (SqlCommand cmd = new SqlCommand(query, connection))
                                                            {
                                                                // پارامترها
                                                                cmd.Parameters.AddWithValue("@id", sysnumcombovalue);
                                                                cmd.Parameters.AddWithValue("@controllerNumber", radcontrollervalueASnum);

                                                                // گرفتن قیمت از دیتابیس
                                                                string queryPrice = "SELECT price FROM priceTB WHERE controllerNumber=@controllerNumber AND systemtype='PS4'";
                                                                decimal price = 0;

                                                                using (SqlCommand cmmd = new SqlCommand(queryPrice, connection))
                                                                {
                                                                    cmmd.Parameters.AddWithValue("@controllerNumber", radcontrollervalueASnum);
                                                                    var result = cmmd.ExecuteScalar();
                                                                    if (result != null)
                                                                    {
                                                                        price = (decimal)result;
                                                                    }
                                                                    else
                                                                    {
                                                                        MessageBox.Show("Price not found for the given controller number.");
                                                                        return;
                                                                    }
                                                                }
                                                                // دریافت مبلغ ورودی کاربر (مبلغ تایم)
                                                                decimal userAmount = 0;
                                                                if (!decimal.TryParse(txb_cstmoney4.Text, out userAmount))
                                                                {
                                                                    MessageBox.Show("مقدار وارد شده صحیح نیست.");
                                                                    return;
                                                                }

                                                                // تقسیم مبلغ ورودی بر قیمت
                                                                decimal resultInSeconds = userAmount / price;

                                                                // تبدیل از ثانیه به دقیقه
                                                                decimal resultInMinutes = resultInSeconds / 60;


                                                                cmd.Parameters.AddWithValue("@price", userAmount);


                                                                // دریافت زمان شروع (startTime) به صورت DateTime
                                                                DateTime startTime = DateTime.Now;  // ساعت و دقیقه فعلی
                                                                cmd.Parameters.AddWithValue("@startTime", startTime);

                                                                // محاسبه زمان پایان (endTime) با اضافه کردن دقیقه‌ها (از resultInMinutes)
                                                                DateTime endTime = startTime.AddMinutes((double)resultInMinutes); // نتیجه از ثانیه به دقیقه تبدیل شده
                                                                cmd.Parameters.AddWithValue("@endTime", endTime);



                                                                // اجرای کوئری
                                                                int rowsAffected = cmd.ExecuteNonQuery();

                                                                if (rowsAffected > 0)
                                                                {
                                                                    displayData4();
                                                                    sysnumcombovalue = "";
                                                                    radcontrollervalue = "";
                                                                    return;
                                                                }
                                                                else
                                                                {
                                                                    MessageBox.Show("Failed to add the record.");
                                                                }
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            MessageBox.Show("Error: " + ex.Message);
                                                        }

                                                    }
                                                }
                                            }
                                            break;
                                    }
                                }
                            }
                        }

                    }
                    break;
                
            }
        }












        // رویداد تغییر آیتم انتخابی در کامبوباکس sysnum_combo5
        private void sysnum_combo5_SelectedIndexChanged(object sender, EventArgs e)
        {
            // بررسی وضعیت انتخاب آیتم و تنظیم رابط کاربری
            CheckSelectedItem_ComboSysNum();
        }

        // رویداد تغییر وضعیت رادیوباکس اول
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // فعال کردن گروه هزینه برای سیستم 5
            cost_grp5.Enabled = true;
        }

        // رویداد تغییر وضعیت رادیوباکس دوم برای سیستم 5
        private void rad_crt2_5_CheckedChanged(object sender, EventArgs e)
        {
            cost_grp5.Enabled = true;
        }

        // رویداد تغییر وضعیت رادیوباکس سوم برای سیستم 5
        private void rad_crt3_5_CheckedChanged(object sender, EventArgs e)
        {
            cost_grp5.Enabled = true;
        }

        // رویداد تغییر وضعیت رادیوباکس چهارم برای سیستم 5
        private void rad_crt4_5_CheckedChanged(object sender, EventArgs e)
        {
            cost_grp5.Enabled = true;
        }

        // رویداد لود فرم، اجرا در هنگام باز شدن فرم
        private void frmAdminPanel_Load(object sender, EventArgs e)
        {
            // افزودن آیتم‌ها به کامبوباکس‌ها
            AddSyscomboItem();
            displayData5();
            displayData4();
            // Set the DataGridView's AutoSizeMode for all columns to fill
            foreach (DataGridViewColumn column in dgv_5.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            foreach (DataGridViewColumn column in dgv_4.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

        }

        // رویداد تغییر آیتم انتخابی در کامبوباکس sysnum_combopc
        private void sysnum_combopc_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        // رویداد تغییر آیتم انتخابی در کامبوباکس sysnum_combo4
        private void sysnum_combo4_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            CheckSelectedItem_ComboSysNum();
        }

        // رویداد تغییر وضعیت رادیوباکس اول برای سیستم 4
        private void rad_crt1_4_CheckedChanged(object sender, EventArgs e)
        {
            cost_grp4.Enabled = true;
        }

        // رویداد تغییر وضعیت رادیوباکس دوم برای سیستم 4
        private void rad_crt2_4_CheckedChanged(object sender, EventArgs e)
        {
            cost_grp4.Enabled = true;
        }

        // رویداد تغییر وضعیت رادیوباکس سوم برای سیستم 4
        private void rad_crt3_4_CheckedChanged(object sender, EventArgs e)
        {
            cost_grp4.Enabled = true;
        }

        // رویداد تغییر وضعیت رادیوباکس چهارم برای سیستم 4
        private void rad_crt4_4_CheckedChanged(object sender, EventArgs e)
        {
            cost_grp4.Enabled = true;
        }

        // رویداد تغییر وضعیت رادیوباکس مرتبط با تنظیم زمان سفارشی
        private void rad_csttime_CheckedChanged(object sender, EventArgs e)
        {
            if (rad_csttime4.Checked) // اگر رادیوباکس زمان سفارشی فعال باشد
            {
                txb_csttime4.Enabled = true; // فعال کردن تکست‌باکس زمان سفارشی
            }
            else
            {
                txb_csttime4.Enabled = false; // غیرفعال کردن تکست‌باکس زمان سفارشی
            }
        }

        // رویداد تغییر وضعیت رادیوباکس مرتبط با تنظیم مبلغ سفارشی
        private void rad_cstmoney_CheckedChanged(object sender, EventArgs e)
        {
            if (rad_cstmoney4.Checked) // اگر رادیوباکس مبلغ سفارشی فعال باشد
            {
                txb_cstmoney4.Enabled = true; // فعال کردن تکست‌باکس مبلغ سفارشی
            }
            else
            {
                txb_cstmoney4.Enabled = false; // غیرفعال کردن تکست‌باکس مبلغ سفارشی
            }
        }

        // رویداد کلیک روی دکمه شروع برای سیستم 5
        private void btn_start5_Click(object sender, EventArgs e)
        {
            // افزودن یک ردیف جدید به داده‌ها
            addDataRow();
        }

        private void btn_stop5_Click(object sender, EventArgs e)
        {
            // بررسی اینکه ردیفی انتخاب شده باشد
            if (dgv_5.CurrentRow != null)
            {
                // استخراج index ردیف انتخاب شده
                int rowIndex = dgv_5.CurrentRow.Index;

                // استخراج id از ستون مربوطه (فرض می‌کنیم ستون id در index 0 قرار دارد)
                var selectedId = dgv_5.Rows[rowIndex].Cells[0].Value.ToString();

                // حذف ردیف از DataGridView
                dgv_5.Rows.RemoveAt(rowIndex);

                // حذف ردیف از دیتابیس
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        // دستور SQL برای حذف ردیف از دیتابیس با استفاده از id
                        string deleteQuery = "DELETE FROM dataGridView5 WHERE id = @id";

                        using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                        {
                            // اضافه کردن پارامتر id به دستور SQL
                            cmd.Parameters.AddWithValue("@id", selectedId);

                            // اجرای دستور
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("ردیف با موفقیت حذف شد.");
                            }
                            else
                            {
                                MessageBox.Show("خطا در حذف ردیف.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("خطا در اتصال به دیتابیس: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("لطفاً یک ردیف را انتخاب کنید.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addDataRow();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // بررسی اینکه ردیفی انتخاب شده باشد
            if (dgv_5.CurrentRow != null)
            {
                // استخراج index ردیف انتخاب شده
                int rowIndex = dgv_5.CurrentRow.Index;

                // استخراج id از ستون مربوطه (فرض می‌کنیم ستون id در index 0 قرار دارد)
                var selectedId = dgv_5.Rows[rowIndex].Cells[0].Value.ToString();

                // حذف ردیف از DataGridView
                dgv_5.Rows.RemoveAt(rowIndex);

                // حذف ردیف از دیتابیس
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        // دستور SQL برای حذف ردیف از دیتابیس با استفاده از id
                        string deleteQuery = "DELETE FROM dataGridView5 WHERE id = @id";

                        using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                        {
                            // اضافه کردن پارامتر id به دستور SQL
                            cmd.Parameters.AddWithValue("@id", selectedId);

                            // اجرای دستور
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("ردیف با موفقیت حذف شد.");
                            }
                            else
                            {
                                MessageBox.Show("خطا در حذف ردیف.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("خطا در اتصال به دیتابیس: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("لطفاً یک ردیف را انتخاب کنید.");
            }
        }

        private void rad_csttime5_CheckedChanged(object sender, EventArgs e)
        {
            if (rad_csttime5.Checked) // اگر رادیوباکس زمان سفارشی فعال باشد
            {
                txb_csttime5.Enabled = true; // فعال کردن تکست‌باکس زمان سفارشی
            }
            else
            {
                txb_csttime5.Enabled = false; // غیرفعال کردن تکست‌باکس زمان سفارشی
            }
        }

        private void rad_cstmoney5_CheckedChanged(object sender, EventArgs e)
        {
            if (rad_cstmoney5.Checked) // اگر رادیوباکس مبلغ سفارشی فعال باشد
            {
                txb_cstmoney5.Enabled = true; // فعال کردن تکست‌باکس مبلغ سفارشی
            }
            else
            {
                txb_cstmoney5.Enabled = false; // غیرفعال کردن تکست‌باکس مبلغ سفارشی
            }
        }
    }
}

