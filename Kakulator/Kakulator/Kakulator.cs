namespace Kakulator
{
    public partial class Kakulator : Form
    {
        private Size formOriginalSize;
        private Rectangle but1;
        private Rectangle but2;
        private Rectangle but3;
        private Rectangle but4;
        private Rectangle but5;
        private Rectangle but6;
        private Rectangle but7;
        private Rectangle but8;
        private Rectangle but9;
        private Rectangle but0;
        private Rectangle butPlus;
        private Rectangle butMinus;
        private Rectangle butMul;
        private Rectangle butDiv;
        private Rectangle butCE;
        private Rectangle butC;
        private Rectangle butDelete;
        private Rectangle butComa;
        private Rectangle butRavno;
        private Rectangle butTextBox;
        private Rectangle butLabel;

        Double result = 0;
        String operationClicked = "";
        bool isOperationClicked = false;

        public Kakulator()
        {
            InitializeComponent();
        }

        private void Kakulator_Load(object sender, EventArgs e)
        {
            formOriginalSize = this.Size;
            but1 = new Rectangle(b1.Location.X, b1.Location.Y, b1.Width, b1.Height);
            but2 = new Rectangle(b2.Location.X, b2.Location.Y, b2.Width, b2.Height);
            but3 = new Rectangle(b3.Location.X, b3.Location.Y, b3.Width, b3.Height);
            but4 = new Rectangle(b4.Location.X, b4.Location.Y, b4.Width, b4.Height);
            but5 = new Rectangle(b5.Location.X, b5.Location.Y, b5.Width, b5.Height);
            but6 = new Rectangle(b6.Location.X, b6.Location.Y, b6.Width, b6.Height);
            but7 = new Rectangle(b7.Location.X, b7.Location.Y, b7.Width, b7.Height);
            but8 = new Rectangle(b8.Location.X, b8.Location.Y, b8.Width, b8.Height);
            but9 = new Rectangle(b9.Location.X, b9.Location.Y, b9.Width, b9.Height);
            but0 = new Rectangle(b0.Location.X, b0.Location.Y, b0.Width, b0.Height);
            butPlus = new Rectangle(bPlus.Location.X, bPlus.Location.Y, bPlus.Width, bPlus.Height);
            butMinus = new Rectangle(bMinus.Location.X, bMinus.Location.Y, bMinus.Width, bMinus.Height);
            butMul = new Rectangle(bMul.Location.X, bMul.Location.Y, bMul.Width, bMul.Height);
            butDiv = new Rectangle(bDiv.Location.X, bDiv.Location.Y, bDiv.Width, bDiv.Height);
            butCE = new Rectangle(bCE.Location.X, bCE.Location.Y, bCE.Width, bCE.Height);
            butC = new Rectangle(bC.Location.X, bC.Location.Y, bC.Width, bC.Height);
            butDelete = new Rectangle(bDelete.Location.X, bDelete.Location.Y, bDelete.Width, bDelete.Height);
            butComa = new Rectangle(bComa.Location.X, bComa.Location.Y, bComa.Width, bComa.Height);
            butRavno = new Rectangle(bRavno.Location.X, bRavno.Location.Y, bRavno.Width, bRavno.Height);
            butTextBox = new Rectangle(textBox1.Location.X, textBox1.Location.Y, textBox1.Width, textBox1.Height);
            butLabel = new Rectangle(label1.Location.X, label1.Location.Y, label1.Width, label1.Height);
        }

        private void resize()
        {
            resizeControl(but1, b1);
            resizeControl(but2, b2);
            resizeControl(but3, b3);
            resizeControl(but4, b4);
            resizeControl(but5, b5);
            resizeControl(but6, b6);
            resizeControl(but7, b7);
            resizeControl(but8, b8);
            resizeControl(but9, b9);
            resizeControl(but0, b0);
            resizeControl(butPlus, bPlus);
            resizeControl(butMinus, bMinus);
            resizeControl(butMul, bMul);
            resizeControl(butDiv, bDiv);
            resizeControl(butCE, bCE);
            resizeControl(butC, bC);
            resizeControl(butDelete, bDelete);
            resizeControl(butComa, bComa);
            resizeControl(butRavno, bRavno);
            resizeControl(butTextBox, textBox1);
            resizeControl(butLabel, label1);
        }

        private void resizeControl(Rectangle OriginalControlRect, Control control)
        {
            float xRatio = (float)(this.Width) / (float)(formOriginalSize.Width);
            float yRatio = (float)(this.Height) / (float)(formOriginalSize.Height);

            int newX = (int)(OriginalControlRect.X * xRatio);
            int newY = (int)(OriginalControlRect.Y * yRatio);

            int newWidth = (int)(OriginalControlRect.Width * xRatio);
            int newHeight = (int)(OriginalControlRect.Height * yRatio);

            control.Location = new Point(newX, newY);
            control.Size = new Size(newWidth, newHeight);
        }

        private void Kakulator_Resize(object sender, EventArgs e)
        {
            resize();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Text != ",")
            {
                if (textBox1.Text == "0" || isOperationClicked) { textBox1.Clear(); }
            }

            if(textBox1.Text == "" || isOperationClicked) {
                if(button.Text == ",")
                {
                    textBox1.Text = "0,";
                }
            }

            isOperationClicked = false;
            if(button.Text == ",")
            {
                if (!textBox1.Text.Contains(",")) { textBox1.Text += button.Text; }
            }
            else
            {
                textBox1.Text += button.Text;
            }
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (!isOperationClicked)
            {
                if (result != 0)
                {
                    bRavno.PerformClick();
                    operationClicked = button.Text;
                    label1.Text = result + " " + operationClicked;
                }
                else
                {
                    operationClicked = button.Text;
                    result = Double.Parse(textBox1.Text);
                    label1.Text = result + " " + operationClicked;
                }
            } else
            {
                operationClicked = button.Text;
                label1.Text = label1.Text.Remove(label1.Text.Length - 1);
                label1.Text += operationClicked;
            }
            isOperationClicked = true;
        }

        private void bCE_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void bC_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            result = 0;
            label1.Text = "";
        }

        private void bRavno_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            switch (operationClicked)
            {
                case "+":
                    textBox1.Text = (result + Double.Parse(textBox1.Text)).ToString();
                    break;
                case "-":
                    textBox1.Text = (result - Double.Parse(textBox1.Text)).ToString();
                    break;
                case "*":
                    textBox1.Text = (result * Double.Parse(textBox1.Text)).ToString();
                    break;
                case "/":
                    textBox1.Text = (result / Double.Parse(textBox1.Text)).ToString();
                    break;
                default:
                    break;
            }
            result = Double.Parse(textBox1.Text);
            operationClicked = "";
        }

        private void Kakulator_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }
    }
}