using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab_9;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Point _currentPoint;
    private Point _savedPoint;
    private bool _isPointSet = false;
    
    public MainWindow()
    {
        InitializeComponent();
        txtResults.Text = "Введите координаты точки и выберите операцию";
    }
    
    private void BtnSetPoint_Click(object sender, RoutedEventArgs e)
    {
        if (double.TryParse(txtX.Text, out double x) && double.TryParse(txtY.Text, out double y))
        {
            _currentPoint = new Point(x, y);
            _savedPoint = new Point(_currentPoint);
            txtResults.Text = $"Создана точка: {_currentPoint}\n";
            _isPointSet = true;
        }
        else
        {
            MessageBox.Show("Введите корректные числа для X и Y", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            _isPointSet = false;
        }
    }
 
    private bool CheckPointIsSet()
    {
        if (!_isPointSet)
        {
            MessageBox.Show("Сначала задайте координаты точки", "Ошибка", 
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return false;
        }
        return true;
    }

    private void AddResult(string operation, object result)
    {
        txtResults.Text += $"{operation}: {result}\n";
    }

    private void BtnDecrement_Click(object sender, RoutedEventArgs e) 
    {
        if (!CheckPointIsSet()) return;
        
        Point result = --_currentPoint;
        AddResult("Уменьшение x и y на 1", result);
        _currentPoint = new Point(_savedPoint);
    }

    private void BtnSwap_Click(object sender, RoutedEventArgs e)
    {
        if (!CheckPointIsSet()) return;
        
        Point result = +_currentPoint;
        AddResult("Смена x и y местами", result);
        _currentPoint = new Point(_savedPoint);
    }

    private void BtnConvertToInt_Click(object sender, RoutedEventArgs e)
    {
        if (!CheckPointIsSet()) return;
        
        int result = (int)_currentPoint;
        AddResult("Приведение к целому x", result);
        _currentPoint = new Point(_savedPoint);
    }

    private void BtnConvertToDouble_Click(object sender, RoutedEventArgs e)
    {
        if (!CheckPointIsSet()) return;
        
        double result = (double)_currentPoint;
        AddResult("Приведение к double y", result);
        _currentPoint = new Point(_savedPoint);
    }

    private void BtnPointMinusValue_Click(object sender, RoutedEventArgs e)
    {
        if (!CheckPointIsSet()) return;
        
        if (int.TryParse(txtValue1.Text, out int value))
        {
            Point result = _currentPoint - value;
            AddResult($"Вычитание {value} из точки", result);
            _currentPoint = new Point(_savedPoint);
        }
        else
        {
            MessageBox.Show("Введите целое число", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void BtnValueMinusPoint_Click(object sender, RoutedEventArgs e)
    {
        if (!CheckPointIsSet()) return;
        
        if (int.TryParse(txtValue2.Text, out int value))
        {
            Point result = value - _currentPoint;
            AddResult($"Вычитание точки из {value}", result);
            _currentPoint = new Point(_savedPoint);
        }
        else
        {
            MessageBox.Show("Введите целое число", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private void BtnDistance_Click(object sender, RoutedEventArgs e)
    {
        if (!CheckPointIsSet()) return;
        
        double result = -_currentPoint;
        AddResult("Расстояние до точки", result);
        _currentPoint = new Point(_savedPoint);
    }
}
    