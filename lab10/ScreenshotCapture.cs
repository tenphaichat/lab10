using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Lab10_DisconnectedData.GUI;

namespace Lab10_DisconnectedData
{
    public static class ScreenshotCapture
    {
        public static Bitmap FrameForm(Form form)
        {
            if (!form.Visible) form.Show();
            Application.DoEvents();
            Thread.Sleep(150);
            Application.DoEvents();

            int clientW = form.ClientSize.Width;
            int clientH = form.ClientSize.Height;

            Bitmap clientBmp = new Bitmap(clientW, clientH, PixelFormat.Format32bppArgb);
            form.DrawToBitmap(clientBmp, new Rectangle(0, 0, clientW, clientH));

            int titleH = 34;
            int borderWidth = 1;
            int totalW = clientW + borderWidth * 2;
            int totalH = clientH + titleH + borderWidth * 2;

            Bitmap finalBmp = new Bitmap(totalW, totalH, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(finalBmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                using (SolidBrush titleBrush = new SolidBrush(Color.FromArgb(243, 243, 243)))
                {
                    g.FillRectangle(titleBrush, 0, 0, totalW, titleH);
                }

                using (Pen iconPen = new Pen(Color.FromArgb(16, 54, 110), 1.6f))
                {
                    g.DrawRectangle(iconPen, 12, 9, 15, 15);
                    g.DrawLine(iconPen, 12, 14, 27, 14);
                }

                using (Font titleFont = new Font("Segoe UI", 9.5f, FontStyle.Regular))
                using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(30, 30, 30)))
                {
                    g.DrawString(form.Text, titleFont, textBrush, 34, 8);
                }

                int btnW = 46;
                int minX = totalW - btnW * 3;
                int maxX = totalW - btnW * 2;
                int closeX = totalW - btnW;

                using (Pen btnPen = new Pen(Color.FromArgb(60, 60, 60), 1.2f))
                {
                    g.DrawLine(btnPen, minX + 18, 17, minX + 28, 17);
                    g.DrawRectangle(btnPen, maxX + 18, 12, 10, 10);
                    g.DrawLine(btnPen, closeX + 18, 12, closeX + 28, 22);
                    g.DrawLine(btnPen, closeX + 28, 12, closeX + 18, 22);
                }

                g.DrawImage(clientBmp, borderWidth, titleH);

                using (Pen borderPen = new Pen(Color.FromArgb(180, 180, 180), 1))
                {
                    g.DrawRectangle(borderPen, 0, 0, totalW - 1, totalH - 1);
                }
            }

            form.Dispose();
            clientBmp.Dispose();
            return finalBmp;
        }

        public static void RunCapture(string outputDir)
        {
            Directory.CreateDirectory(outputDir);
            Console.WriteLine("Capturing screenshots for Lab 10 directly from WinForms project...");

            // 1. Dashboard Overview / Bài 1: Fill DataTable
            {
                var form = new frmMain();
                form.Size = new Size(1184, 684);
                form.Show();
                form.SwitchTab(0);
                using (var bmp = FrameForm(form))
                {
                    bmp.Save(Path.Combine(outputDir, "Lab10_Dashboard_Overview.png"), ImageFormat.Png);
                    bmp.Save(Path.Combine(outputDir, "Lab10_Bai1_FillDataTable.png"), ImageFormat.Png);
                }
                Console.WriteLine("Captured Bai 1 & Overview.");
            }

            // 2. Bài 2 & 3: DataSet nhiều bảng & DataRelation Master-Detail
            {
                var form = new frmMain();
                form.Size = new Size(1184, 684);
                form.Show();
                form.SwitchTab(1); // Tab 2
                using (var bmp = FrameForm(form))
                {
                    bmp.Save(Path.Combine(outputDir, "Lab10_Bai2_DataSetMultiTables.png"), ImageFormat.Png);
                    bmp.Save(Path.Combine(outputDir, "Lab10_Bai3_DataRelationMasterDetail.png"), ImageFormat.Png);
                }
                Console.WriteLine("Captured Bai 2 & Bai 3.");
            }

            // 3. Bài 4: Lọc và Sắp xếp bằng DataView
            {
                var form = new frmMain();
                form.Size = new Size(1184, 684);
                form.Show();
                form.SwitchTab(2); // Tab 3
                form.ApplyDataViewFilter();
                using (var bmp = FrameForm(form))
                {
                    bmp.Save(Path.Combine(outputDir, "Lab10_Bai4_DataViewFilterSort.png"), ImageFormat.Png);
                }
                Console.WriteLine("Captured Bai 4.");
            }

            // 4. Bài 5: SqlCommandBuilder Update
            {
                var form = new frmMain();
                form.Size = new Size(1184, 684);
                form.Show();
                form.SwitchTab(0); // Tab 1
                form.SaveToDatabase();
                using (var bmp = FrameForm(form))
                {
                    bmp.Save(Path.Combine(outputDir, "Lab10_Bai5_SqlCommandBuilderUpdate.png"), ImageFormat.Png);
                }
                Console.WriteLine("Captured Bai 5.");
            }

            // 5. Bài 6: DataTable thủ công & Cột biểu thức
            {
                var form = new frmMain();
                form.Size = new Size(1184, 684);
                form.Show();
                form.SwitchTab(3); // Tab 4
                using (var bmp = FrameForm(form))
                {
                    bmp.Save(Path.Combine(outputDir, "Lab10_Bai6_ManualDataTableExpression.png"), ImageFormat.Png);
                }
                Console.WriteLine("Captured Bai 6.");
            }

            // 6. Bài 7: Theo dõi RowState bằng GetChanges()
            {
                var form = new frmMain();
                form.Size = new Size(1184, 684);
                form.Show();
                form.SwitchTab(4); // Tab 5
                // Sửa 1 dòng, thêm 1 dòng để minh họa RowState
                var btnSua = form.Controls.Find("btnBai7_SuaMau", true);
                if (btnSua.Length > 0 && btnSua[0] is Button b1) b1.PerformClick();
                var btnThem = form.Controls.Find("btnBai7_ThemMau", true);
                if (btnThem.Length > 0 && btnThem[0] is Button b2) b2.PerformClick();
                form.AuditRowState();

                using (var bmp = FrameForm(form))
                {
                    bmp.Save(Path.Combine(outputDir, "Lab10_Bai7_RowStateAudit.png"), ImageFormat.Png);
                }
                Console.WriteLine("Captured Bai 7.");
            }

            // 7. Bài 8: AcceptChanges & RejectChanges
            {
                var form = new frmMain();
                form.Size = new Size(1184, 684);
                form.Show();
                form.SwitchTab(4); // Tab 5
                form.PerformRejectChanges(); // Minh họa hoàn tác
                using (var bmp = FrameForm(form))
                {
                    bmp.Save(Path.Combine(outputDir, "Lab10_Bai8_AcceptRejectChanges.png"), ImageFormat.Png);
                }
                Console.WriteLine("Captured Bai 8.");
            }

            // 8. Bài 9: Ghi và Đọc XML kèm Schema
            {
                var form = new frmMain();
                form.Size = new Size(1184, 684);
                form.Show();
                form.SwitchTab(5); // Tab 6
                form.ExportXmlWithSchema();
                using (var bmp = FrameForm(form))
                {
                    bmp.Save(Path.Combine(outputDir, "Lab10_Bai9_DataSetXmlSchema.png"), ImageFormat.Png);
                }
                Console.WriteLine("Captured Bai 9.");
            }

            // 9. Bài 10: Hợp nhất DataTable bằng Merge
            {
                var form = new frmMain();
                form.Size = new Size(1184, 684);
                form.Show();
                form.SwitchTab(6); // Tab 7
                form.PerformMerge();
                using (var bmp = FrameForm(form))
                {
                    bmp.Save(Path.Combine(outputDir, "Lab10_Bai10_DataTableMerge.png"), ImageFormat.Png);
                }
                Console.WriteLine("Captured Bai 10.");
            }

            Console.WriteLine("All screenshots captured successfully!");
        }
    }
}
