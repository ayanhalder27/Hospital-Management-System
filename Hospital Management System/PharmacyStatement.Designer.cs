namespace Hospital_Management_System
{
    partial class PharmacyStatement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.pnlTop = new Guna.UI2.WinForms.Guna2Panel();
            this.controlBoxMinimize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.controlBoxMaximize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.controlBoxClose = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.comboFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dgvStatement = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblTotalProfitText = new System.Windows.Forms.Label();
            this.lblTotalProfitValue = new System.Windows.Forms.Label();
            this.billingID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoice = new System.Windows.Forms.DataGridViewLinkColumn();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatement)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 25;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.BorderRadius = 25;
            this.guna2ShadowForm1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.controlBoxMinimize);
            this.pnlTop.Controls.Add(this.controlBoxMaximize);
            this.pnlTop.Controls.Add(this.controlBoxClose);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.btnBack);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.pnlTop.Size = new System.Drawing.Size(1267, 98);
            this.pnlTop.TabIndex = 0;
            // 
            // controlBoxMinimize
            // 
            this.controlBoxMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.controlBoxMinimize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.controlBoxMinimize.FillColor = System.Drawing.Color.White;
            this.controlBoxMinimize.IconColor = System.Drawing.Color.Gray;
            this.controlBoxMinimize.Location = new System.Drawing.Point(1101, 6);
            this.controlBoxMinimize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.controlBoxMinimize.Name = "controlBoxMinimize";
            this.controlBoxMinimize.Size = new System.Drawing.Size(47, 43);
            this.controlBoxMinimize.TabIndex = 7;
            // 
            // controlBoxMaximize
            // 
            this.controlBoxMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.controlBoxMaximize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MaximizeBox;
            this.controlBoxMaximize.FillColor = System.Drawing.Color.White;
            this.controlBoxMaximize.IconColor = System.Drawing.Color.Gray;
            this.controlBoxMaximize.Location = new System.Drawing.Point(1156, 6);
            this.controlBoxMaximize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.controlBoxMaximize.Name = "controlBoxMaximize";
            this.controlBoxMaximize.Size = new System.Drawing.Size(47, 43);
            this.controlBoxMaximize.TabIndex = 6;
            // 
            // controlBoxClose
            // 
            this.controlBoxClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.controlBoxClose.FillColor = System.Drawing.Color.White;
            this.controlBoxClose.IconColor = System.Drawing.Color.Gray;
            this.controlBoxClose.Location = new System.Drawing.Point(1211, 6);
            this.controlBoxClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.controlBoxClose.Name = "controlBoxClose";
            this.controlBoxClose.Size = new System.Drawing.Size(47, 43);
            this.controlBoxClose.TabIndex = 5;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(77)))), ((int)(((byte)(160)))));
            this.lblTitle.Location = new System.Drawing.Point(459, 30);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(308, 41);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Pharmacy Statement";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BorderRadius = 12;
            this.btnBack.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBack.FillColor = System.Drawing.Color.White;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Image = global::Hospital_Management_System.Properties.Resources.back;
            this.btnBack.ImageSize = new System.Drawing.Size(40, 40);
            this.btnBack.Location = new System.Drawing.Point(31, 22);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.ShadowDecoration.BorderRadius = 12;
            this.btnBack.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.btnBack.ShadowDecoration.Enabled = true;
            this.btnBack.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 5, 5);
            this.btnBack.Size = new System.Drawing.Size(78, 55);
            this.btnBack.TabIndex = 4;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // comboFilter
            // 
            this.comboFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboFilter.BackColor = System.Drawing.Color.Transparent;
            this.comboFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.comboFilter.BorderRadius = 8;
            this.comboFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFilter.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboFilter.ItemHeight = 30;
            this.comboFilter.Items.AddRange(new object[] {
            "All",
            "This Month",
            "This Year"});
            this.comboFilter.Location = new System.Drawing.Point(997, 119);
            this.comboFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboFilter.Name = "comboFilter";
            this.comboFilter.Size = new System.Drawing.Size(239, 36);
            this.comboFilter.StartIndex = 0;
            this.comboFilter.TabIndex = 1;
            this.comboFilter.SelectedIndexChanged += new System.EventHandler(this.comboFilter_SelectedIndexChanged);
            // 
            // dgvStatement
            // 
            this.dgvStatement.AllowUserToAddRows = false;
            this.dgvStatement.AllowUserToDeleteRows = false;
            this.dgvStatement.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvStatement.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvStatement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStatement.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(77)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(77)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStatement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvStatement.ColumnHeadersHeight = 40;
            this.dgvStatement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvStatement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.billingID,
            this.customerName,
            this.contact,
            this.billedBy,
            this.date,
            this.subtotal,
            this.discount,
            this.total,
            this.invoice});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStatement.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvStatement.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvStatement.Location = new System.Drawing.Point(31, 186);
            this.dgvStatement.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvStatement.Name = "dgvStatement";
            this.dgvStatement.ReadOnly = true;
            this.dgvStatement.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStatement.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvStatement.RowHeadersVisible = false;
            this.dgvStatement.RowHeadersWidth = 51;
            this.dgvStatement.RowTemplate.Height = 35;
            this.dgvStatement.Size = new System.Drawing.Size(1207, 491);
            this.dgvStatement.TabIndex = 2;
            this.dgvStatement.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvStatement.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvStatement.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvStatement.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvStatement.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvStatement.ThemeStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvStatement.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvStatement.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvStatement.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvStatement.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvStatement.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvStatement.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvStatement.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvStatement.ThemeStyle.ReadOnly = true;
            this.dgvStatement.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvStatement.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvStatement.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvStatement.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvStatement.ThemeStyle.RowsStyle.Height = 35;
            this.dgvStatement.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvStatement.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvStatement.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStatement_CellContentClick);
            // 
            // lblTotalProfitText
            // 
            this.lblTotalProfitText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalProfitText.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProfitText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTotalProfitText.Location = new System.Drawing.Point(877, 713);
            this.lblTotalProfitText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalProfitText.Name = "lblTotalProfitText";
            this.lblTotalProfitText.Size = new System.Drawing.Size(167, 31);
            this.lblTotalProfitText.TabIndex = 3;
            this.lblTotalProfitText.Text = "Total Profit:";
            this.lblTotalProfitText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalProfitValue
            // 
            this.lblTotalProfitValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalProfitValue.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProfitValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(77)))), ((int)(((byte)(160)))));
            this.lblTotalProfitValue.Location = new System.Drawing.Point(1052, 713);
            this.lblTotalProfitValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalProfitValue.Name = "lblTotalProfitValue";
            this.lblTotalProfitValue.Size = new System.Drawing.Size(185, 31);
            this.lblTotalProfitValue.TabIndex = 6;
            this.lblTotalProfitValue.Text = "---";
            this.lblTotalProfitValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // billingID
            // 
            this.billingID.DataPropertyName = "Pharmacy_Billing_ID";
            this.billingID.HeaderText = "Billing ID";
            this.billingID.MinimumWidth = 6;
            this.billingID.Name = "billingID";
            this.billingID.ReadOnly = true;
            // 
            // customerName
            // 
            this.customerName.DataPropertyName = "CustomerName";
            this.customerName.HeaderText = "Customer Name";
            this.customerName.MinimumWidth = 6;
            this.customerName.Name = "customerName";
            this.customerName.ReadOnly = true;
            // 
            // contact
            // 
            this.contact.DataPropertyName = "PhoneNumber";
            this.contact.HeaderText = "Contact";
            this.contact.MinimumWidth = 6;
            this.contact.Name = "contact";
            this.contact.ReadOnly = true;
            // 
            // billedBy
            // 
            this.billedBy.DataPropertyName = "biller";
            this.billedBy.HeaderText = "Billed by";
            this.billedBy.MinimumWidth = 6;
            this.billedBy.Name = "billedBy";
            this.billedBy.ReadOnly = true;
            // 
            // date
            // 
            this.date.DataPropertyName = "Date";
            this.date.HeaderText = "Date";
            this.date.MinimumWidth = 6;
            this.date.Name = "date";
            this.date.ReadOnly = true;
            // 
            // subtotal
            // 
            this.subtotal.DataPropertyName = "Subtotal";
            this.subtotal.HeaderText = "Subtotal";
            this.subtotal.MinimumWidth = 6;
            this.subtotal.Name = "subtotal";
            this.subtotal.ReadOnly = true;
            // 
            // discount
            // 
            this.discount.DataPropertyName = "Discount";
            this.discount.HeaderText = "Discount";
            this.discount.MinimumWidth = 6;
            this.discount.Name = "discount";
            this.discount.ReadOnly = true;
            // 
            // total
            // 
            this.total.DataPropertyName = "Total";
            this.total.HeaderText = "Total";
            this.total.MinimumWidth = 6;
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // invoice
            // 
            this.invoice.DataPropertyName = "Invoice";
            this.invoice.HeaderText = "Invoice";
            this.invoice.MinimumWidth = 6;
            this.invoice.Name = "invoice";
            this.invoice.ReadOnly = true;
            // 
            // PharmacyStatement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1267, 775);
            this.Controls.Add(this.lblTotalProfitValue);
            this.Controls.Add(this.lblTotalProfitText);
            this.Controls.Add(this.dgvStatement);
            this.Controls.Add(this.comboFilter);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PharmacyStatement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PharmacyStatement";
            this.Load += new System.EventHandler(this.PharmacyStatement_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatement)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2ComboBox comboFilter;
        private Guna.UI2.WinForms.Guna2DataGridView dgvStatement;
        private Guna.UI2.WinForms.Guna2Button btnBack;
        private System.Windows.Forms.Label lblTotalProfitText;
        private System.Windows.Forms.Label lblTotalProfitValue;
        private Guna.UI2.WinForms.Guna2ControlBox controlBoxClose;
        private Guna.UI2.WinForms.Guna2ControlBox controlBoxMinimize;
        private Guna.UI2.WinForms.Guna2ControlBox controlBoxMaximize;
        private System.Windows.Forms.DataGridViewTextBoxColumn billingID;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn contact;
        private System.Windows.Forms.DataGridViewTextBoxColumn billedBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewLinkColumn invoice;
    }
}

