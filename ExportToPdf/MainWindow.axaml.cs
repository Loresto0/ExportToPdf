using System;
using System.Collections.Generic;
using Avalonia.Controls;
using SkiaSharp;

namespace ExportToPdf;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        // Создаём pdf файл с помощью SkiaSharp // AppDomain.CurrentDomain.BaseDirectory - путь к папке .net 7
        using (var doc = SKDocument.CreatePdf(AppDomain.CurrentDomain.BaseDirectory + "Отчёт.pdf" ))
        {
            // Открытие страницы в документе // Задаём высоту и ширину по стандарту А4
            using (var canvas = doc.BeginPage(595,842))
            {
                // Создание текстового объекта
                using (var paint = new SKPaint())
                {
                    paint.IsAntialias = true;
                    paint.TextSize = 24;
                    paint.Color = SKColors.Black;

                    // Запись текста на страницу
                    canvas.DrawText("Привет прбшка!", 100, 100, paint);
                }
                // Завершение страницы
                doc.EndPage();
            }
            // Закрытие документа
            doc.Close();
        }
    }
}