using Odev.Model;

namespace Odev
{
    public partial class Form1 : Form
    {
        ContactsContext _db;
        public Form1()
        {
            InitializeComponent();
            _db = new ContactsContext();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgwList.DataSource = _db.Contacts.ToList();
        }

        private void btnListed_Click(object sender, EventArgs e)
        {
            dgwList.DataSource = _db.Contacts.ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Contact contact = new Contact();
                contact.FirstName = tbFirstName.Text;
                contact.LastName = tbLastName.Text;
                contact.PhoneNumber = tbPhoneNumber.Text;
                contact.ContactId = Convert.ToInt32(tbID.Text);
                _db.Contacts.Add(contact);
                _db.SaveChanges();
                dgwList.DataSource = _db.Contacts.ToList();
            }
            catch (Exception ex )
            {

                throw new Exception(ex.Message);
            }
        }

        private void btnSearching_Click(object sender, EventArgs e)
        {
            try
            {
                string searchingWords = tbFirstName.Text;
                var searchingContacts = _db.Contacts.Where(x => x.FirstName.Contains(searchingWords)).ToList();
                dgwList.DataSource = searchingContacts;
            }
            catch (Exception)
            {

                throw new Exception("Pls Check Your Entries!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Contact updatedContact =(Contact)dgwList.SelectedRows[0].DataBoundItem;
            updatedContact.FirstName= tbFirstName.Text;
            updatedContact.LastName= tbLastName.Text;
            updatedContact.PhoneNumber= tbPhoneNumber.Text;
            _db.Contacts.Update(updatedContact);
            _db.SaveChanges();
            dgwList.DataSource = _db.Contacts.ToList();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Contact deletedContact = dgwList.SelectedRows[0].DataBoundItem as Contact;
            _db.Contacts.Remove(deletedContact);
            _db.SaveChanges();
            dgwList.DataSource= _db.Contacts.ToList();
        }
    }
}