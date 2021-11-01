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
using System.Configuration;

namespace FinalTermProject
{
    public partial class Home : Form
    {

        int xLast, yLast, quantity;
        bool mouseDown;
        double total;
        string strCon = ConfigurationManager.ConnectionStrings["FinalTermProject.Properties.Settings.ConnectionString"].ToString();


        //----------------------------------------HOME-----------------------------------------

        public Home()
        {
            InitializeComponent();

            panel_Home.Visible = true;
            panel_AddMem.Visible = false;
            panel_Mem_Info.Visible = false;
            panel_Update_Member.Visible = false;
            panel_Purchase_Product.Visible = false;
            panel_Admin.Visible = false;
            button_New_Members.Show();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            panel_Home.Visible = true;
            panel_AddMem.Visible = false;
            panel_Mem_Info.Visible = false;
            panel_Update_Member.Visible = false;
            panel_Purchase_Product.Visible = false;
            panel_Admin.Visible = false;
        }


   

        private void buttonClose(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimiseTab(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }



        private void headerPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;

            xLast = e.X;
            yLast = e.Y;
        }

        private void headerPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                int newX = this.Left + (e.X - xLast);
                int newY = this.Top + (e.Y - yLast);
                this.Location = new Point(newX, newY);
            }
        }

        private void headerPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }


        private void button14_Click(object sender, EventArgs e)//image gallery
        {
            try
            {
                System.Diagnostics.Process.Start("explorer.exe", @"E:\Wallpapers\New folder");
            }
            catch (Win32Exception win32Exception)
            {
                Console.WriteLine(win32Exception.Message);
            }
        }


        //-----------------------------------END OF HOME------------------------------------------



        //----------------------------------ADD MEMBER--------------------------------------------


        private void ad_mem_click(object sender, EventArgs e)
        {
            panel_AddMem.Visible = true;
            panel_Home.Visible = false;
            panel_Mem_Info.Visible = false;
            panel_Update_Member.Visible = false;
            panel_Purchase_Product.Visible = false;
            panel_Admin.Visible = false;

        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            MemberTableDataContext mi = new MemberTableDataContext(strCon);

            try
            {

                Member mt = new Member
                {
                    Id = int.Parse(textBox_Id.Text),
                    Name = textName.Text,
                    Age = textBox_Age.Text,
                    Gender = comboBox_Gender.Text,
                    Height = textHeight.Text,
                    Weight = textWeight.Text,
                    Contact = textContact.Text,
                    Batch = comboBatch.Text,
                    Member_Type = comboMember.Text,
                    Fees_Mode = comboFees.Text

                };
                if (int.Parse(textBox_Age.Text) < 100 && int.Parse(textBox_Age.Text) > 0)
                {
                    mi.Members.InsertOnSubmit(mt);
                    mi.SubmitChanges();
                    MessageBox.Show("Success!");
                }
                else
                {
                    MessageBox.Show("Please input a valid age!");
                }
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }



        private void button_Clear_2_Click(object sender, EventArgs e)
        {
            textBox_Id.Text = textName.Text = textBox_Age.Text = comboBox_Gender.Text = textHeight.Text =
                    textWeight.Text = textContact.Text = comboBatch.Text = comboMember.Text
                = comboFees.Text = string.Empty;
        }

        //-----------------------------------END OF ADD MEMBER-----------------------------------------




        //--------------------------------------MEMBER INFO---------------------------------------------


        private void b1_Click(object sender, EventArgs e)
        {
            panel_Mem_Info.Visible = true;
            panel_Home.Visible = false;
            panel_Purchase_Product.Visible = false;
            panel_AddMem.Visible = false;
            panel_Update_Member.Visible = false;
            panel_Admin.Visible = false;

            MemberTableDataContext m = new MemberTableDataContext(strCon);
            dataGridView1.DataSource = m.Members;

        }


        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            MemberTableDataContext mi = new MemberTableDataContext(strCon);
            dataGridView1.DataSource = mi.Members;

           
        }


        //-----------------------------------END OF MEMBER INFO-----------------------------------------





        //--------------------------------------UPDATE MEMBER-------------------------------------------

        private void b3_Click(object sender, EventArgs e)//Update Frame button
        {

            MemberTableDataContext m = new MemberTableDataContext(strCon);

            dataGrid_Update_List.DataSource = m.Members;

            panel_Mem_Info.Visible = false;
            panel_Purchase_Product.Visible = false;
            panel_Home.Visible = false;
            panel_AddMem.Visible = false;
            panel_Update_Member.Visible = true;
            panel_Admin.Visible = false;


        }

        private void buttonMemSearch_Click(object sender, EventArgs e)//SEARCH button in Update info Panel
        {
            MemberTableDataContext mi = new MemberTableDataContext(strCon);
            try
            {
                if (int.Parse(textBox_Up_Id.Text) >= 0)
                {
                    var x = from a in mi.Members
                            where a.Id == int.Parse(textBox_Up_Id.Text)
                            select a;

                    {

                        textBox_Up_name.Text = x.FirstOrDefault().Name;
                        comboBox_Up_Gen.Text = x.First().Gender;
                        textBox_Up_Age.Text = x.First().Age;
                        textBox_Up_Height.Text = x.First().Height;
                        textBox_Up_Weight.Text = x.First().Weight;
                        textBox_Up_Contact.Text = x.First().Contact;
                        comboBox_Up_batch.Text = x.First().Batch;
                        comboBox_Up_Mem.Text = x.First().Member_Type;
                        comboBox_Up_Fees.Text = x.First().Fees_Mode;

                        dataGrid_Update_List.DataSource = x.ToList();


                    }

                }
                else
                {
                    MessageBox.Show("ID must be positive integer!");
                }

            }

            catch
            {
                MessageBox.Show("Invalid ID!");
            }

        }


        private void buttonUpdate_Click(object sender, EventArgs e) //Update Button in Update Info Panel
        {
            MemberTableDataContext mi = new MemberTableDataContext(strCon);
            if (textBox_Up_Id.Text != "")
            {

                try
                {
                    var x = from a in mi.Members
                            where a.Id == int.Parse(textBox_Up_Id.Text)
                            select a;
                    x.First().Id = int.Parse(textBox_Up_Id.Text);
                    x.First().Name = textBox_Up_name.Text;
                    x.First().Gender = comboBox_Up_Gen.Text;
                    x.First().Age = textBox_Up_Age.Text;
                    x.First().Height = textBox_Up_Height.Text;
                    x.First().Weight = textBox_Up_Weight.Text;
                    x.First().Contact = textBox_Up_Contact.Text;
                    x.First().Batch = comboBox_Up_batch.Text;
                    x.First().Member_Type = comboBox_Up_Mem.Text;
                    x.First().Fees_Mode = comboBox_Up_Fees.Text;

                    mi.SubmitChanges();
                    dataGrid_Update_List.DataSource = x.ToList();
                }
                catch
                {
                    MessageBox.Show("Invalid Entry!");
                }
            }
            else
            {
                MessageBox.Show("Input ID First!");
            }


        }


        private void buttonDelete_Click(object sender, EventArgs e) //DELETE Button in Update Info Panel 
        {
            MemberTableDataContext mi = new MemberTableDataContext(strCon);
            try
            {
                var x = from a in mi.Members
                        where a.Id == int.Parse(textBox_Up_Id.Text)
                        select a;
                //Lamda Expression

                foreach (Member m in x)
                {
                    mi.Members.DeleteOnSubmit(m);
                }

                mi.SubmitChanges();
                //UpdateGridView();
                MessageBox.Show("Success!");
            }
            catch
            {
                MessageBox.Show("Unsuccessful!");
            }

        }

        private void buttonLoad_Click(object sender, EventArgs e) //REFRESH Button in Update info Panel
        {

            MemberTableDataContext mi = new MemberTableDataContext(strCon);

            dataGrid_Update_List.DataSource = mi.Members;

            textBox_Up_Id.Text =
            textBox_Up_name.Text =
            comboBox_Up_Gen.Text =
            textBox_Up_Age.Text =
            textBox_Up_Height.Text =
            textBox_Up_Weight.Text =
            textBox_Up_Contact.Text =
            comboBox_Up_batch.Text =
            comboBox_Up_Mem.Text =
            comboBox_Up_Fees.Text = string.Empty;

        }


        private void dataGrid_Update_List_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = (int)dataGrid_Update_List.Rows[(dataGrid_Update_List.SelectedCells[0].RowIndex)].Cells[0].Value;
            textBox_Up_name.Text = dataGrid_Update_List.Rows[(dataGrid_Update_List.SelectedCells[0].RowIndex)].Cells[1].Value.ToString();
            textBox_Up_Age.Text = dataGrid_Update_List.Rows[(dataGrid_Update_List.SelectedCells[0].RowIndex)].Cells[2].Value.ToString();
            comboBox_Up_Gen.Text = dataGrid_Update_List.Rows[(dataGrid_Update_List.SelectedCells[0].RowIndex)].Cells[3].Value.ToString();
            textBox_Up_Height.Text = dataGrid_Update_List.Rows[(dataGrid_Update_List.SelectedCells[0].RowIndex)].Cells[4].Value.ToString();
            textBox_Up_Weight.Text = dataGrid_Update_List.Rows[(dataGrid_Update_List.SelectedCells[0].RowIndex)].Cells[5].Value.ToString();
            comboBox_Up_batch.Text = dataGrid_Update_List.Rows[(dataGrid_Update_List.SelectedCells[0].RowIndex)].Cells[7].Value.ToString();
            comboBox_Up_Mem.Text = dataGrid_Update_List.Rows[(dataGrid_Update_List.SelectedCells[0].RowIndex)].Cells[9].Value.ToString();
            comboBox_Up_Fees.Text = dataGrid_Update_List.Rows[(dataGrid_Update_List.SelectedCells[0].RowIndex)].Cells[8].Value.ToString();
            textBox_Up_Contact.Text = dataGrid_Update_List.Rows[(dataGrid_Update_List.SelectedCells[0].RowIndex)].Cells[6].Value.ToString();
            textBox_Up_Id.Text = dataGrid_Update_List.Rows[(dataGrid_Update_List.SelectedCells[0].RowIndex)].Cells[0].Value.ToString();
        }


        //-----------------------------------END OF UPDATE INFO-----------------------------------------





        //-----------------------------------PURCHASE PRODUCT-----------------------------------------

        private void b4_Click(object sender, EventArgs e)//PRODUCT PURCHASE Button
        {
            ProductTableDataContext pd = new ProductTableDataContext(strCon);
            dataGrid_Purchase.DataSource = pd.Products.ToList();

            panel_Mem_Info.Visible = false;
            panel_Purchase_Product.Visible = true;
            panel_Home.Visible = false;
            panel_AddMem.Visible = false;
            panel_Update_Member.Visible = false;
            panel_Admin.Visible = false;
        }

        //TIMER
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label_Notice.Left < -250)
            {
                label_Notice.Left = 300;
            }
            else
            {
                label_Notice.Left -= 5;
            }

        }

        private void button_Prod_Search_Click(object sender, EventArgs e)//Product Search
        {
            ProductTableDataContext p = new ProductTableDataContext(strCon);
            try
            {
                var x = from a in p.Products
                        where a.Id == int.Parse(textBox_Prod_Search.Text) || a.Name.Equals(textBox_Prod_Search.Text)
                        select a;

                {

                    label_Prod_Name.Text = x.FirstOrDefault().Name;
                    label_Bill_1.Text = x.First().Name;
                    text_pID.Text = x.First().Id.ToString();
                    textBox_Pd_Id.Text = x.First().Id.ToString();
                    text_Pd_Name.Text = x.First().Name;
                    text_Pd_Quantity.Text = x.First().Quantity.ToString();
                    text_Pd_Price.Text = x.First().Price.ToString();


                    button_Purchase.Visible = true;
                    pictureBox2.Visible = true;

                    dataGrid_Purchase.DataSource = x.ToList();
                }

            }
            catch
            {
                MessageBox.Show("Not Found!");
            }
        }

        private void button_Purchase_Click(object sender, EventArgs e) //SELECT ITEM (PRODUCT)
        {

            groupBox_Bill.Visible = true;

        }



        private void buttonRefresh_P_Click(object sender, EventArgs e) //REFRESH PRODUCT Button
        {
            ProductTableDataContext pd = new ProductTableDataContext(strCon);
            dataGrid_Purchase.DataSource = pd.Products.ToList();
            textBox_Prod_Search.Text = "";
            pictureBox2.Visible = false;
            label_Prod_Name.Text = "";
            button_Purchase.Visible = false;
            textBox_Pd_Id.Text = "";
            text_Pd_Name.Text = "";
            text_Pd_Quantity.Text = "";
            text_Pd_Price.Text = "";

        }



        private void button8_Click(object sender, EventArgs e)//UPDATE PRODUCT Button
        {
            ProductTableDataContext p = new ProductTableDataContext(strCon);
            if (textBox_Pd_Id.Text != "")
            {

                try
                {
                    var x = from a in p.Products
                            where a.Id == int.Parse(textBox_Pd_Id.Text)
                            select a;

                    x.First().Id = int.Parse(textBox_Pd_Id.Text);
                    x.First().Name = text_Pd_Name.Text;
                    x.First().Quantity = Double.Parse(text_Pd_Quantity.Text);
                    x.First().Price = Double.Parse(text_Pd_Price.Text);

                    p.SubmitChanges();
                    dataGrid_Purchase.DataSource = x.ToList();

                    MessageBox.Show("Update Successful!");
                }
                catch
                {
                    MessageBox.Show("Invalid Entry!");
                }
            }
            else
            {
                MessageBox.Show("Input ID First!");
            }
        }



        private void button6_Click(object sender, EventArgs e)//ADD PRODUCT Button
        {
            ProductTableDataContext p = new ProductTableDataContext(strCon);

            try
            {

                Product pd = new Product
                {
                    Id = int.Parse(textBox_Pd_Id.Text),
                    Name = text_Pd_Name.Text,
                    Quantity = Double.Parse(text_Pd_Quantity.Text),
                    Price = Double.Parse(text_Pd_Price.Text)

                };

                p.Products.InsertOnSubmit(pd);
                p.SubmitChanges();
                dataGrid_Purchase.DataSource = p.Products.ToList();

                MessageBox.Show("Success!");

            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        private void button_Edit_Prod_Click(object sender, EventArgs e) //ADD/EDIT PRODUCT Button
        {
            groupBox_Prod.Visible = true;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)//CLOSE BUTTON
        {
            groupBox_Prod.Visible = false;
        }

        //-----------------------------------END OF PURCHASE PRODUCT-----------------------------------------




        //----------------------------------------BILL SECTION-----------------------------------------------

        private void text_pID_TextChanged(object sender, EventArgs e)//PRODUCT ID (BILL SECTION)
        {

            if (text_pID.Equals(null) || text_pID.Text.Any())
            {
                ProductTableDataContext p = new ProductTableDataContext(strCon);
                try
                {
                    var x = from a in p.Products
                            where a.Id == int.Parse(text_pID.Text)
                            select a;

                    {

                        label_Bill_1.Text = x.FirstOrDefault().Name;
                        textBox_Rate.Text = x.First().Price.ToString();
                        text_Quantity.Text = "";


                    }
                }
                catch
                {
                    MessageBox.Show("Please insert a valid product ID");
                }
            }
        }


        private void text_Quantity_TextChanged(object sender, EventArgs e)//QUANTITY Textbox (BILL SECTION)
        {

            if (text_Quantity.Equals(null) || text_Quantity.Text.Any())
            {
                try
                {
                    ProductTableDataContext p = new ProductTableDataContext(strCon);

                    quantity = int.Parse(text_Quantity.Text);

                    var x = from a in p.Products
                            where a.Id == int.Parse(text_pID.Text)
                            select a;


                    textBox_Rate.Text = x.First().Price.ToString();
                    labelAmount.Text = ((x.First().Price) * quantity).ToString();



                    p.SubmitChanges();
                }
                catch
                {
                    MessageBox.Show("Invalid Entry!");
                }
            }

        }


        private void button2_Click_1(object sender, EventArgs e) //ADD Items (BILL SECTIOIN)
        {
            ProductTableDataContext p = new ProductTableDataContext(strCon);

            var x = from a in p.Products
                    where a.Id == int.Parse(text_pID.Text)
                    select a;

            if (text_Quantity.Text == "" || int.Parse(text_Quantity.Text) == 0 || textBox_Rate.Equals(null))
               {

                        MessageBox.Show("Please input quantity!");
                }
            else
               {
                   try
                   {

                       if (x.First().Quantity >= int.Parse(text_Quantity.Text))
                       {


                           string s = ((x.First().Price) * quantity).ToString();

                           labelAmount.Text = s;

                           dataGridView_Bill.Rows.Add(text_pID.Text, x.First().Name, textBox_Rate.Text, text_Quantity.Text, s);

                       }

                       else
                       {
                           MessageBox.Show("Stock Out!");
                       }
                   }
                   catch
                   {
                       MessageBox.Show("Error!");

                   }

            }
        }

        private void button9_Click(object sender, EventArgs e)//BILL Button (BILL SECTION)
        {
            ProductTableDataContext p = new ProductTableDataContext(strCon);



            try
            {
                for (int i = 0; i < dataGridView_Bill.Rows.Count; i++)
                {
                    total += Double.Parse(dataGridView_Bill.Rows[i].Cells["PrdAmount"].Value.ToString());
                }


                labelAmnt.Text = total.ToString();

                MessageBox.Show("Your Bill : " + total + "TK");

                var x = from a in p.Products
                        where a.Id == int.Parse(text_pID.Text)
                        select a;

                {

                    x.First().Quantity -= Double.Parse(text_Quantity.Text);

                    p.SubmitChanges();
                    dataGrid_Purchase.DataSource = x.ToList();

                }
            }
            catch
            {
                MessageBox.Show("Unsuccessful!");
            }

        }

        private void button10_Click(object sender, EventArgs e)//REMOVE Item (BILL SECTION)
        {
            try
            {
                int rowIndex = dataGridView_Bill.CurrentCell.RowIndex;
                dataGridView_Bill.Rows.RemoveAt(rowIndex);
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }


        private void button16_Click(object sender, EventArgs e) //REFRESH Button (BILL SECTION)
        {
            text_pID.Text = "";
            textBox_Rate.Text = "";
            text_Quantity.Text = "";
            labelAmount.Text = "";
            labelAmnt.Text = "";
            dataGridView_Bill.Rows.Clear();
            label_Bill_1.Text = "";
        }


    

        private void bunifuFlatButton4_Click(object sender, EventArgs e)//CLOSE BUTTON
        {
            groupBox_Bill.Visible = false;
        }


        //-----------------------------------END OF BILL SECTION-----------------------------------------



        //-------------------------------------ADD/REMOVE ADMIN------------------------------------------

        private void b5_Click(object sender, EventArgs e)//ADD/REMOVE Admin Button
        {
           
            panel_Mem_Info.Visible = false;
            panel_Purchase_Product.Visible = false;
            panel_Home.Visible = false;
            panel_AddMem.Visible = false;
            panel_Update_Member.Visible = false;
            panel_Admin.Visible = true;


        }

        private void button4_Click(object sender, EventArgs e)//ADD Admin
        {
            if (textBox2.Text != "" && textBox3.Text != "")
            {
                if (textBox3.Text.Length >= 4)
                {
                    LinqLoginDataContext lq = new LinqLoginDataContext(strCon);
                    Login lg = new Login
                    {
                        Username = textBox2.Text,
                        Password = textBox3.Text
                    };

                    MessageBox.Show("Admin added successfully!");
                    lq.Logins.InsertOnSubmit(lg);
                    lq.SubmitChanges();
                    // UpdateGridView();
                }
                else
                {
                    MessageBox.Show("Password must have minimum 4 characters!");
                }
            }
            else
            {
                MessageBox.Show("(Error!) Input username & password!");
            }

        }

        private void button7_Click(object sender, EventArgs e) //CLEAR (ADMIN SECTION)
        {
            textBox2.Text = textBox3.Text = textBox4.Text = string.Empty;
        }


        private void button5_Click(object sender, EventArgs e)//REMOVE Admin
        {

            LinqLoginDataContext lq = new LinqLoginDataContext(strCon);

            if (textBox4.Text != "")
            {
                var x = from a in lq.Logins
                        where a.Username.Equals(textBox4.Text)
                        select a;

                //Lamda Expression
                foreach (Login l in x)
                {
                    lq.Logins.DeleteOnSubmit(l);
                }

                lq.SubmitChanges();
                dataGrid_Admin_List.DataSource = lq;
            }
            else
            {
                MessageBox.Show("Input an Admin name!");
            }
         }

        private void button1_Click(object sender, EventArgs e)//EDIT Password (ADMIN SECTION)
        {

            panel_Verify.Visible = true;

        }

        private void button3_Click(object sender, EventArgs e)//CANCEL Button (ADMIN SECTION)
        {
            panel_Verify.Visible = false;
        }

        private void button_Verify_Update_Click(object sender, EventArgs e)//UPDATE Password Button (ADMIN SECTION)
        {
            if (textBox_New_Pass.Text != "")
            {
                try
                {
                    LinqLoginDataContext lq = new LinqLoginDataContext(strCon);

                    var x = from a in lq.Logins
                            where a.Password == textBox_Old_Pass.Text
                            select a;

                    x.First().Password = textBox_New_Pass.Text;

                    lq.SubmitChanges();
                    dataGrid_Admin_List.DataSource = x.ToList();

                    MessageBox.Show("Success!");
                }
                catch
                {
                    MessageBox.Show("Wrong Password! Try again.");
                }
            }
            else
            {
                MessageBox.Show("Please insert a new password");
              
            }
        }


        private void panel_Admin_Paint(object sender, PaintEventArgs e)//Admin list
        {
            LinqLoginDataContext lq = new LinqLoginDataContext(strCon);
            var y = from g in lq.Logins
                    select new
                    {
                        Name = g.Username
                    };

            dataGrid_Admin_List.DataSource = y.ToList();
        }

        //-----------------------------------END OF ADD/REMOVE ADMIN-----------------------------------------



        //-------------------------------------------OTHER---------------------------------------------------


        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            LoginForm lg = new LoginForm();
            this.Hide();
            lg.Show();
        }

 
        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

    }

}