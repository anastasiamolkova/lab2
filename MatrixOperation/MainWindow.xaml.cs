using System;
using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Microsoft.Win32;
using MatrixLibrary;

namespace MatrixOperation
{
    public partial class MainWindow : Window
    {
        private Matrix<int>? _matrixA;
        private Matrix<int>? _matrixB;
        private Matrix<int>? _matrixC;
        private int N;
        private bool _operationMessageShown = false;

        public MainWindow()
        {
            InitializeComponent();

            AmendMatrix(matrixADataGrid);
            AmendMatrix(matrixBDataGrid);
            AmendMatrix(matrixCDataGrid);

            btnEnter.Click += BtnEnter_Click;
            btnCalculate.Click += BtnCalculate_Click;
            btnSave.Click += BtnSave_Click;
            matrixADataGrid.CellEditEnding += MatrixADataGrid_CellEditEnding;
            matrixBDataGrid.CellEditEnding += MatrixBDataGrid_CellEditEnding;
        }

        private void MatrixADataGrid_CellEditEnding(object? sender, DataGridCellEditEndingEventArgs e) => _matrixA[e.Row.GetIndex(), e.Column.DisplayIndex] = Convert.ToInt32((e.EditingElement as TextBox).Text);

        private void MatrixBDataGrid_CellEditEnding(object? sender, DataGridCellEditEndingEventArgs e) => _matrixB[e.Row.GetIndex(), e.Column.DisplayIndex] = Convert.ToInt32((e.EditingElement as TextBox).Text);

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (_matrixA == null || _matrixB == null)
            {
                MessageBox.Show("Матрицы не инициализированы.");
                return;
            }

            Matrix<int> resultMatrix;
            Stopwatch stopwatch = new Stopwatch();

            // Выбор операции
            string selectedOperation = (cbOperation.SelectedItem as ComboBoxItem)?.Content.ToString();
            if (!_operationMessageShown)
            {
                MessageBox.Show($"Выбрана операция: {selectedOperation}");
                _operationMessageShown = true;
            }

            stopwatch.Start();

            if (selectedOperation == "Сложение")
            {
                resultMatrix = MatrixOperations.Add(_matrixA, _matrixB);
            }
            else if (selectedOperation == "Умножение")
            {
                resultMatrix = MatrixOperations.Multiply(_matrixA, _matrixB);
            }
            else
            {
                MessageBox.Show("Неверная операция.");
                return;
            }

            stopwatch.Stop();
            TimeSpan timeTaken = stopwatch.Elapsed;
            MessageBox.Show($"Время выполнения: {timeTaken.TotalMilliseconds} мс");

            // Отображение результата в DataGrid
            _matrixC = resultMatrix;
            matrixCDataGrid.ItemsSource = ConvertArrayToDataTable(resultMatrix.Array).DefaultView;
            matrixCDataGrid.Columns.Clear();

            for (int i = 0; i < N; i++)
            {
                DataGridTextColumn column = new DataGridTextColumn();
                column.Binding = new Binding("[" + i + "]");
                matrixCDataGrid.Columns.Add(column);
            }

            btnSave.IsEnabled = true;
        }

        private void AmendMatrix(DataGrid matrixDataGrid)
        {
            matrixDataGrid.CanUserAddRows = false;
            matrixDataGrid.CanUserDeleteRows = true;
            matrixDataGrid.CanUserReorderColumns = true;
            matrixDataGrid.CanUserSortColumns = false;
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            btnCalculate.IsEnabled = true;
            N = Convert.ToInt32(tbSizeInput.Text);

            _matrixA = null;
            _matrixB = null;
            _operationMessageShown = false; // Сбрасываем флаг при новом вводе
            ChangeValueForMatrix(matrixADataGrid);
            ChangeValueForMatrix(matrixBDataGrid);
        }

        private void ChangeValueForMatrix(DataGrid matrixDataGrid)
        {
            bool randomize = cbRandomize.IsChecked.Value;
            Func<int, int, int> generator = (i, j) => randomize ? Random.Shared.Next(10) : 0;
            Matrix<int> matrix = Matrix<int>.GenerateMatrix(N, N, generator);

            matrixDataGrid.ItemsSource = ConvertArrayToDataTable(matrix.Array).DefaultView;

            matrixDataGrid.Columns.Clear();
            for (int i = 0; i < N; i++)
            {
                DataGridTextColumn column = new DataGridTextColumn();
                column.Binding = new Binding("[" + i + "]");
                matrixDataGrid.Columns.Add(column);
            }

            if (_matrixA == null)
                _matrixA = matrix;
            else
                _matrixB = matrix;
        }

        private DataTable ConvertArrayToDataTable(int[,] array)
        {
            DataTable dataTable = new DataTable();

            for (int i = 0; i < array.GetLength(1); i++)
            {
                dataTable.Columns.Add("Column " + (i + 1));
            }

            for (int i = 0; i < array.GetLength(0); i++)
            {
                DataRow row = dataTable.NewRow();
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    row[j] = array[i, j];
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_matrixC == null)
            {
                MessageBox.Show("Результирующая матрица не рассчитана.");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog.DefaultExt = "csv";

            if (saveFileDialog.ShowDialog() == true)
            {
                _matrixC.SaveToCsv(saveFileDialog.FileName);
                MessageBox.Show("Матрица успешно сохранена.");
            }
        }
    }
}