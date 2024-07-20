/******************************************************************************
 * 作者:      ee4ga9d@gmail.com
 * 日期:      2024-07-18
 * 描述:      自定义日历组件，显示每日待办事项、日期、农历、月份、年度。
 * 版本:      1.0
 * 版权:      x.com/0EE4GA9d © 2024
 ******************************************************************************/
namespace EbbinghausMemoryApp.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
    using System.Windows.Forms;


    public class CustomCalendar : Control
    {
        private DateTime currentMonth;
        private Button prevButton;
        private Button nextButton;
        private EventHandler<DateChangedEventArgs> dateChanged;
        private EventHandler<DateClickedEventArgs> dateClicked;
        private EventHandler<DateDoubleClickedEventArgs> dateDoubleClicked;
        private ChineseLunisolarCalendar chineseCalendar;
        private Dictionary<DateTime, List<ToDoItem>> toDoItems;
        private DateTime? selectedDate;



        public event EventHandler<DateDoubleClickedEventArgs> DateDoubleClicked
        {
            add { dateDoubleClicked += value; }
            remove { dateDoubleClicked -= value; }
        }
        public event EventHandler<DateChangedEventArgs> DateChanged
        {
            add { dateChanged += value; }
            remove { dateChanged -= value; }
        }

        public event EventHandler<DateClickedEventArgs> DateClicked
        {
            add { dateClicked += value; }
            remove { dateClicked -= value; }
        }

        public DateTime? SelectedDate
        {
            get { return selectedDate; }
            set
            {
                selectedDate = value;
                Invalidate();
            }
        }
        public DateTime CurrentMonth
        {
            get => currentMonth;
        }
        public Dictionary<DateTime, List<ToDoItem>> ToDoItems
        {
            get { return toDoItems; }
        }

        public CustomCalendar()
        {
            currentMonth = DateTime.Today.AddDays(-DateTime.Today.Day + 1);
            prevButton = new Button { Text = "<", Width = 30, Height = 30 };
            nextButton = new Button { Text = ">", Width = 30, Height = 30 };
            chineseCalendar = new ChineseLunisolarCalendar();
            toDoItems = new Dictionary<DateTime, List<ToDoItem>>();
            selectedDate = null;

            prevButton.Click += PrevButton_Click;
            nextButton.Click += NextButton_Click;

            Controls.Add(prevButton);
            Controls.Add(nextButton);

            DoubleBuffered = true;

            SetStyle(ControlStyles.ResizeRedraw, true);
            Size = new Size(250, 250);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawCalendar(e.Graphics);
        }

        Font _titleFont = new Font("华文中宋", 16, FontStyle.Bold);

        Font _weekFont = new Font("宋体", 12, FontStyle.Bold);
        Pen _weekPen = new Pen(Color.Black, 2);

        Font _dayFont = new Font("Arial", 12, FontStyle.Bold);
        Font _todoFont1 = new Font("Arial", 10, FontStyle.Strikeout);
        Font _todoFont2 = new Font("Arial", 10, FontStyle.Bold);
        private void DrawCalendar(Graphics g)
        {
            int dayWidth = ClientSize.Width / 7;
            int dayHeight = (ClientSize.Height - 40 - _dayFont.Height) / 6;

            // 绘制年份和月份
            g.DrawString($"{currentMonth:yyyy年MM月}", _titleFont, Brushes.Black, new PointF(Width / 2 - 50, 0));

            SizeF sfTitle = g.MeasureString($"{currentMonth:yyyy年MM月}", _titleFont);

            // 绘制上一个月和下一个月按钮
            prevButton.Location = new Point(Width / 2 - 50 - 10 - 30, 0);
            nextButton.Location = new Point(Width / 2 - 50 + (int)sfTitle.Width + 10, 0);

            string[] chineseDays = { "周日", "周一", "周二", "周三", "周四", "周五", "周六" };
            for (int i = 0; i < chineseDays.Length; i++)
            {
                // 绘制星期几标题
                Brush brush = (i == 0 || i == 6) ? Brushes.Red : Brushes.Black;

                g.DrawString(chineseDays[i], _weekFont, brush, i * dayWidth + dayWidth / 2, 36, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near });
            }

            DateTime startDate = currentMonth;
            while (startDate.DayOfWeek != DayOfWeek.Sunday)
                startDate = startDate.AddDays(-1);

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    DateTime day = startDate.AddDays(i * 7 + j);
                    Rectangle rect = new Rectangle(j * dayWidth, 40 + Font.Height + i * dayHeight, dayWidth, dayHeight);

                    // 绘制日期背景
                    g.FillRectangle(Brushes.White, rect);

                    // 绘制日期边框
                    g.DrawRectangle(Pens.Black, rect);

                    // 如果是当前月的日期，则绘制
                    if (day.Month == currentMonth.Month)
                    {
                        // 选中日期背景
                        if (selectedDate.HasValue && day == selectedDate.Value)
                        {
                            g.FillRectangle(Brushes.LightBlue, rect);
                        }

                        //// 日历日期
                        string dayText = day.Day.ToString();
                        SizeF textSize = g.MeasureString(dayText, _dayFont);
                        float x = rect.Left + rect.Width / 2 - textSize.Width / 2;
                        float y = rect.Top + _dayFont.Height / 2;

                        // 农历日期
                        string lunarDate = GetLunarDate(day);
                        SizeF lunarTextSize = g.MeasureString(lunarDate, new Font(Font.FontFamily, Font.Size * 0.7f));
                        float lunarX = rect.Right - lunarTextSize.Width - 2; // 靠右对齐，留一点间距
                        float lunarY = rect.Top + 2; // 靠单元格右上角对齐
                        g.DrawString(lunarDate, new Font(Font.FontFamily, Font.Size * 0.7f), Brushes.Gray, lunarX, y);

                        // 标记今天
                        if (day == DateTime.Today)
                        {
                            // 绘制蓝色圆圈，稍大于日期数字
                            float ellipseSize = textSize.Width + 1; // 比数字宽度稍大一些
                            float ellipseX = x + 1;// rect.Left + (rect.Width - ellipseSize) / 2;
                            float ellipseY = y - 4;//rect.Top;// + (  ellipseSize)/2 ;
                            g.FillEllipse(Brushes.Blue, ellipseX, ellipseY, ellipseSize, ellipseSize);
                            g.DrawEllipse(Pens.Blue, ellipseX, ellipseY, ellipseSize, ellipseSize);

                            // 使用白色加粗字体
                            g.DrawString(dayText, new Font(_dayFont, FontStyle.Bold), Brushes.White, x, y);
                        }
                        else
                        {
                            g.DrawString(dayText, _dayFont, Brushes.Black, x, y);
                        }

                        // 绘制待办事项
                        if (toDoItems.ContainsKey(day))
                        {
                            int offset = (int)(_todoFont1.GetHeight() * 1.2);
                            int maxItemsToShow = (dayHeight - (int)(_todoFont1.GetHeight() * 1.5)) / offset;
                            int itemsCount = toDoItems[day].Count;

                            for (int k = 0; k < maxItemsToShow && k < itemsCount; k++)
                            {
                                var item = toDoItems[day][k];
                                var brush = item.IsCompleted ? Brushes.Pink : Brushes.Red;
                                var textBrush = item.IsCompleted ? Brushes.Gray : Brushes.Black;
                                var font = item.IsCompleted ? _todoFont1 : _todoFont2;

                                // 绘制底色
                                RectangleF itemRect = new RectangleF(rect.Left + 2, rect.Top + Font.Height + (k + 1) * offset-1, rect.Width - 4, offset-1);
                                g.FillRectangle(brush, itemRect);

                                // 绘制待办事项文字
                                g.DrawString(item.Description, font, textBrush, itemRect, new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center });
                            }

                            // 如果待办事项超过显示的最大数量，显示"还有多少项"
                            if (itemsCount > maxItemsToShow)
                            {
                                string moreItemsText = $"还有 {itemsCount - maxItemsToShow} 项...";
                                RectangleF moreItemsRect = new RectangleF(rect.Left + 2, rect.Top + Font.Height + (maxItemsToShow + 1) * offset, rect.Width - 4, offset);
                                g.DrawString(moreItemsText, new Font(Font.FontFamily, Font.Size * 0.7f), Brushes.Black, moreItemsRect, new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center });
                            }
                        }
                    }
                    else
                    {
                        // 非当前月的日期，灰色显示
                        g.DrawString(day.Day.ToString(), Font, Brushes.Gray, rect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                    }
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            int dayWidth = ClientSize.Width / 7;
            int dayHeight = (ClientSize.Height - 30 - Font.Height) / 6;

            int column = e.X / dayWidth;
            int row = (e.Y - 30 - Font.Height) / dayHeight;

            if (column >= 0 && column < 7 && row >= 0 && row < 6)
            {
                DateTime startDate = currentMonth;
                while (startDate.DayOfWeek != DayOfWeek.Sunday)
                    startDate = startDate.AddDays(-1);

                DateTime selectedDay = startDate.AddDays(row * 7 + column);

                if (selectedDay.Month == currentMonth.Month)
                {
                    selectedDate = selectedDay;
                    dateClicked?.Invoke(this, new DateClickedEventArgs(selectedDay));
                    Invalidate();
                }
            }
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);

            int dayWidth = ClientSize.Width / 7;
            int dayHeight = (ClientSize.Height - 30 - Font.Height) / 6;

            int column = e.X / dayWidth;
            int row = (e.Y - 30 - Font.Height) / dayHeight;

            if (column >= 0 && column < 7 && row >= 0 && row < 6)
            {
                DateTime startDate = currentMonth;
                while (startDate.DayOfWeek != DayOfWeek.Sunday)
                    startDate = startDate.AddDays(-1);

                DateTime selectedDay = startDate.AddDays(row * 7 + column);

                if (selectedDay.Month == currentMonth.Month)
                {
                    selectedDate = selectedDay;
                    dateDoubleClicked?.Invoke(this, new DateDoubleClickedEventArgs(selectedDay));
                    Invalidate();
                }
            }
        }


        private void PrevButton_Click(object sender, EventArgs e)
        {
            currentMonth = currentMonth.AddMonths(-1);
            dateChanged?.Invoke(this, new DateChangedEventArgs(currentMonth));
            Invalidate();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            currentMonth = currentMonth.AddMonths(1);
            dateChanged?.Invoke(this, new DateChangedEventArgs(currentMonth));
            Invalidate();
        }

        private string GetLunarDate(DateTime date)
        {
            int lunarYear = chineseCalendar.GetYear(date);
            int lunarMonth = chineseCalendar.GetMonth(date);
            int lunarDay = chineseCalendar.GetDayOfMonth(date);

            bool isLeapMonth = false;

            // Determine if it is a leap month
            int leapMonth = chineseCalendar.GetLeapMonth(lunarYear);
            if (leapMonth > 0)
            {
                if (lunarMonth == leapMonth)
                {
                    isLeapMonth = true;
                }
                if (lunarMonth > leapMonth)
                {
                    lunarMonth--;
                }
            }

            string[] chineseMonths = { "正月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "冬月", "腊月" };
            string[] chineseDays = { "初一", "初二", "初三", "初四", "初五", "初六", "初七", "初八", "初九", "初十",
                                 "十一", "十二", "十三", "十四", "十五", "十六", "十七", "十八", "十九", "二十",
                                 "廿一", "廿二", "廿三", "廿四", "廿五", "廿六", "廿七", "廿八", "廿九", "三十" };

            string lunarDate = (isLeapMonth ? "闰" : "") + chineseMonths[lunarMonth - 1] + chineseDays[lunarDay - 1];

            return lunarDate;
        }

        public void SetToDoItems(Dictionary<DateTime, List<ToDoItem>> items)
        {
            toDoItems.Clear();
            foreach (var kvp in items)
            {
                toDoItems[kvp.Key] = kvp.Value;
            }
            Invalidate();
        }

        public void ClearToDoItems()
        {
            toDoItems.Clear();
            Invalidate();
        }

        public void AddToDoItem(DateTime date, ToDoItem item)
        {
            if (!toDoItems.ContainsKey(date))
                toDoItems[date] = new List<ToDoItem>();

            toDoItems[date].Add(item);
            Invalidate();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            Invalidate();
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            Invalidate();
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            Invalidate();
        }
    }


    public class DateDoubleClickedEventArgs : EventArgs
    {
        public DateTime ClickedDate { get; private set; }

        public DateDoubleClickedEventArgs(DateTime clickedDate)
        {
            ClickedDate = clickedDate;
        }
    }

    public class DateChangedEventArgs : EventArgs
    {
        public DateTime NewDate { get; }

        public DateChangedEventArgs(DateTime newDate)
        {
            NewDate = newDate;
        }
    }

    public class DateClickedEventArgs : EventArgs
    {
        public DateTime ClickedDate { get; }

        public DateClickedEventArgs(DateTime clickedDate)
        {
            ClickedDate = clickedDate;
        }
    }

}
