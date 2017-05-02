using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using BusinessLogicLayer;
using DataAccessLayer;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            TabPage page = tabControl1.SelectedTab; ;

            var tp2 = page.Controls;
            foreach (Control item in tp2)
            {
                if (item is TextBox||item is ComboBox)
                {
                    item.Text = "";
                }
            }
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            ResizeForm(tabPage1);
        }

        private void ResizeForm(TabPage tbpg)
        {
            int maxleft = 0;
            int maxheight = 0;
            foreach (Control item in tbpg.Controls)
            {
                if (maxleft < (item.Location.X + item.Width))
                {
                    maxleft = item.Location.X + item.Width;
                }
                if (maxheight < (item.Location.Y + item.Height))
                {
                    maxheight = item.Location.Y + item.Height;
                }
            }
            ((Form)Application.OpenForms["Form1"]).Width = maxleft+30;
            ((Form)Application.OpenForms["Form1"]).Height = maxheight+70;
           
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
           
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            ResizeForm(tabPage2);
        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            ResizeForm(tabPage3);
        }

        private void tabPage4_Enter(object sender, EventArgs e)
        {
            ResizeForm(tabPage4);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AllRefresh();

            
        }

        private void AllRefresh()
        {
            cmbFonksiyonBulKategoriSecDoldur();
            cmbFonksiyonEkleKategoriSecDoldur();
            cmbFonksiyonDuzenleYeniKategoriSecDoldur();
            lstKategoriIslemleriKategoriGosterDoldur();
        }

        private void lstKategoriIslemleriKategoriGosterDoldur()
        {
            lstKategoriIslemleriKategoriGoster.Items.Clear();
            CategoryReposiyory CatRepository = new CategoryReposiyory();
            List<Category> CatList = CatRepository.GetAll();
            foreach (Category item in CatList)
            {
                ListViewItem li = new ListViewItem();
                li.Text = item.Name;
                li.SubItems.Add(item.Description);
                li.Tag = item;
                lstKategoriIslemleriKategoriGoster.Items.Add(li);
            }
        }

        private void cmbFonksiyonDuzenleYeniKategoriSecDoldur()
        {
            ComboBoxKategoriSecDoldur(cmbFonksiyonDuzenleYeniKategoriSec);
        }

        private void cmbFonksiyonEkleKategoriSecDoldur()
        {
            ComboBoxKategoriSecDoldur(cmbFonksiyonEkleKategoriSec);
        }

        private void ComboBoxKategoriSecDoldur(ComboBox cmb)
        {
            cmbFonksiyonBulKategoriSec.Items.Clear();
            CategoryReposiyory CatRepository = new CategoryReposiyory();
            foreach (Category item in CatRepository.GetAll())
            {
                cmb.Items.Add(item);
            }
        }

        private void cmbFonksiyonBulKategoriSecDoldur()
        {
            ComboBoxKategoriSecDoldur(cmbFonksiyonBulKategoriSec);

        }

        private void btnKategoriIslemleriKategoriEkle_Click(object sender, EventArgs e)
        {
            if (btnKategoriIslemleriKategoriDuzenle_Kaydet.Text== "Düzenle")
            {
                Category Cat = new Category();
                Cat.Name = txtKategoriIslemleriKategoriAdi.Text;
                Cat.Description = txtKategoriIslemleriKategoriAciklamasi.Text;
                if (CategoryProcess.SaveObjectWithControl(Cat))
                {
                    MessageBox.Show("Kategori Ekleme İşlemi Başarılı");
                    AllRefresh();
                }
                else
                {
                    MessageBox.Show("Kategori Ekleme İşlemi BAŞARISIZ");
                }

            }
            else
            {
                MessageBox.Show("Lütfen Önce Düzenleme İşlemini Bitiriniz");
            }


        }

        private void btnKategoriIslemleriKategoriSil_Click(object sender, EventArgs e)
        {
            Category CatToDelete = (Category)lstKategoriIslemleriKategoriGoster.FocusedItem.Tag;
            if (CategoryProcess.DeleteObjectWithControl(CatToDelete))
            {
                MessageBox.Show("Kategori Silme İşlemi Başarılı");
                AllRefresh();
            }
            else
            {
                MessageBox.Show("Kategori Silme İşlemi BAŞARISIZ");
            }
            
        }

        private void btnKategoriIslemleriKategoriDuzenle_Kaydet_Click(object sender, EventArgs e)
        {
            if (btnKategoriIslemleriKategoriDuzenle_Kaydet.Text== "Düzenle")
            {
                if (lstKategoriIslemleriKategoriGoster.FocusedItem!=null)
                {
                    btnKategoriIslemleriDuzenlemeIptal.Visible = true;
                    btnKategoriIslemleriKategoriDuzenle_Kaydet.Text = "Kaydet";
                    btnKategoriIslemleriKategoriDuzenle_Kaydet.Tag = lstKategoriIslemleriKategoriGoster.FocusedItem.Tag;
                    Category CatToEdit = (Category)btnKategoriIslemleriKategoriDuzenle_Kaydet.Tag;
                    txtKategoriIslemleriKategoriAdi.Text = CatToEdit.Name;
                    txtKategoriIslemleriKategoriAciklamasi.Text = CatToEdit.Description;
                }
                else
                {
                    MessageBox.Show("Lütfen Düzenlemek İçin Kategori Seçiniz");
                }
               

            }
            else
            {
                btnKategoriIslemleriDuzenlemeIptal.Visible = false;
                btnKategoriIslemleriKategoriDuzenle_Kaydet.Text = "Düzenle";
                Category CatToEdit = (Category)btnKategoriIslemleriKategoriDuzenle_Kaydet.Tag;
                CatToEdit.Name = txtKategoriIslemleriKategoriAdi.Text;
                CatToEdit.Description = txtKategoriIslemleriKategoriAciklamasi.Text;
                if (CategoryProcess.UpdateObjectWithControl(CatToEdit))
                {
                    MessageBox.Show("Kategori Düzenleme Başarılı");
                    btnKategoriIslemleriKategoriDuzenle_Kaydet.Tag = null;
                    lstKategoriIslemleriKategoriGosterDoldur();
                }
                else
                {
                    MessageBox.Show("Kategori Düzenleme Başarısız");
                }
                
            }
            

        }

        private void btnFonksiyonDuzenleYeniKategoriEkle_Click(object sender, EventArgs e)
        {
            
        }

        private void btnFonksiyonEkleKategoriEkle_Click(object sender, EventArgs e)
        {
            Category CatToAdd = (Category)cmbFonksiyonEkleKategoriSec.SelectedItem;
            ListViewItem li = new ListViewItem();
            li.Text = CatToAdd.Name;
            li.SubItems.Add(CatToAdd.Description);
            li.Tag = CatToAdd;
            bool varmi = false;
            foreach (ListViewItem item in lstFonksiyonEkleKategoriGoster.Items)
            {
                if (((Category)item.Tag).CategoryID==CatToAdd.CategoryID)
                {
                    varmi = true;
                }
            }
            if (!varmi)
            {
                lstFonksiyonEkleKategoriGoster.Items.Add(li);
            }
            
        }

        private void btnFonksiyonEkleKategoriCikar_Click(object sender, EventArgs e)
        {
            if (lstFonksiyonEkleKategoriGoster.FocusedItem!=null)
            {
                lstFonksiyonEkleKategoriGoster.Items.Remove(lstFonksiyonEkleKategoriGoster.FocusedItem);
            }
        }

        private void btnFonksiyonEkleFonksiyonuEkle_Click(object sender, EventArgs e)
        {
            Function FuncToAdd = new Function();
            FuncToAdd.Name = txtFonksiyonEkleAdGir.Text;
            FuncToAdd.Description = txtFonksiyonEkleAciklamaGir.Text;
            FuncToAdd.Code = txtFonksiyonEkleKodGir.Text;
            
            List<int> FuncToAddCategories = new List<int>();
            foreach (ListViewItem item in lstFonksiyonEkleKategoriGoster.Items)
            {
                int CatID = ((Category)item.Tag).CategoryID;
                FuncToAddCategories.Add(CatID);
            }
            FuncToAdd.Categories = FuncToAddCategories;
            if (FunctionProcess.SaveObjectWithControl(FuncToAdd))
            {
                MessageBox.Show("Yeni Fonksiyon Ekleme Başarılı");
            }
            else
            {
                MessageBox.Show("Yeni Fonksiyon Ekleme BAŞARISIZ");
            }
            
        }
    }
}
