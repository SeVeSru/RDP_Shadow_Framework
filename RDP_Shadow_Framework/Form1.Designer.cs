using System.Windows.Forms;

namespace RDP_Shadow_Framework
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.sessionListView = new System.Windows.Forms.ListView();
            this.Username = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SessionID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OfficePhone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.refreshButton = new System.Windows.Forms.Button();
            this.shadowButton = new System.Windows.Forms.Button();
            this.AutoUpdate = new System.Windows.Forms.CheckBox();
            this.checkControl = new System.Windows.Forms.CheckBox();
            this.serverComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // sessionListView
            // 
            this.sessionListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Username,
            this.SessionID,
            this.columnHeader1,
            this.columnHeader2,
            this.Email,
            this.OfficePhone});
            this.sessionListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sessionListView.FullRowSelect = true;
            this.sessionListView.HideSelection = false;
            this.sessionListView.Location = new System.Drawing.Point(0, 0);
            this.sessionListView.Margin = new System.Windows.Forms.Padding(0);
            this.sessionListView.Name = "sessionListView";
            this.sessionListView.Size = new System.Drawing.Size(709, 703);
            this.sessionListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.sessionListView.TabIndex = 9;
            this.sessionListView.UseCompatibleStateImageBehavior = false;
            this.sessionListView.View = System.Windows.Forms.View.Details;
            this.sessionListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.sessionListView_MouseDoubleClick);
            // 
            // Username
            // 
            this.Username.Text = "Имя пользователя";
            this.Username.Width = 100;
            // 
            // SessionID
            // 
            this.SessionID.Text = "ID";
            this.SessionID.Width = 0;
            // 
            // columnHeader1
            // 
            this.columnHeader1.DisplayIndex = 5;
            this.columnHeader1.Text = "Активный";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 2;
            this.columnHeader2.Text = "ФИО";
            this.columnHeader2.Width = 300;
            // 
            // Email
            // 
            this.Email.DisplayIndex = 3;
            this.Email.Text = "E-mail";
            this.Email.Width = 150;
            // 
            // OfficePhone
            // 
            this.OfficePhone.DisplayIndex = 4;
            this.OfficePhone.Text = "Телефон";
            this.OfficePhone.Width = 150;
            // 
            // refreshButton
            // 
            this.refreshButton.AutoSize = true;
            this.refreshButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.refreshButton.Location = new System.Drawing.Point(0, 672);
            this.refreshButton.Margin = new System.Windows.Forms.Padding(4);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(709, 31);
            this.refreshButton.TabIndex = 10;
            this.refreshButton.Text = "Обновить (F5)";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click_1);
            // 
            // shadowButton
            // 
            this.shadowButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.shadowButton.Location = new System.Drawing.Point(0, 642);
            this.shadowButton.Margin = new System.Windows.Forms.Padding(4);
            this.shadowButton.Name = "shadowButton";
            this.shadowButton.Size = new System.Drawing.Size(709, 30);
            this.shadowButton.TabIndex = 11;
            this.shadowButton.Text = "Подключится";
            this.shadowButton.UseVisualStyleBackColor = true;
            this.shadowButton.Click += new System.EventHandler(this.shadowButton_Click_1);
            // 
            // AutoUpdate
            // 
            this.AutoUpdate.AutoSize = true;
            this.AutoUpdate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AutoUpdate.Location = new System.Drawing.Point(0, 604);
            this.AutoUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.AutoUpdate.Name = "AutoUpdate";
            this.AutoUpdate.Size = new System.Drawing.Size(709, 19);
            this.AutoUpdate.TabIndex = 16;
            this.AutoUpdate.Text = "Автообновление списка каждые 10 сек";
            this.AutoUpdate.UseVisualStyleBackColor = true;
            this.AutoUpdate.CheckedChanged += new System.EventHandler(this.AutoUpdate_CheckedChanged);
            // 
            // checkControl
            // 
            this.checkControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.checkControl.Location = new System.Drawing.Point(0, 623);
            this.checkControl.Name = "checkControl";
            this.checkControl.Size = new System.Drawing.Size(709, 19);
            this.checkControl.TabIndex = 17;
            this.checkControl.Text = "Управление";
            this.checkControl.UseVisualStyleBackColor = true;
            // 
            // serverComboBox
            // 
            this.serverComboBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.serverComboBox.FormattingEnabled = true;
            this.serverComboBox.Location = new System.Drawing.Point(0, 581);
            this.serverComboBox.Name = "serverComboBox";
            this.serverComboBox.Size = new System.Drawing.Size(709, 23);
            this.serverComboBox.TabIndex = 19;
            this.serverComboBox.Text = "Ваш сервер";
            this.serverComboBox.SelectedIndexChanged += new System.EventHandler(this.refreshButton_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(709, 703);
            this.Controls.Add(this.serverComboBox);
            this.Controls.Add(this.AutoUpdate);
            this.Controls.Add(this.checkControl);
            this.Controls.Add(this.shadowButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.sessionListView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(421, 742);
            this.Name = "Form1";
            this.Text = "Запаска RDP";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ListView sessionListView;
        private Button refreshButton;
        private Button shadowButton;
        private ColumnHeader SessionID;
        private ColumnHeader Username;
        private CheckBox AutoUpdate;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private CheckBox checkControl;
        private ComboBox serverComboBox;
        private ColumnHeader Email;
        private ColumnHeader OfficePhone;
    }
}

