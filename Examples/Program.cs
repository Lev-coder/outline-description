using System;
using OpenCvSharp;
using RecognizerLib;
using RecognizerLib.Approximators;
using RecognizerLib.Finders;
using RecognizerLib.CatchСontours;
using RecognizerLib.PreparersImage;
using RecognizerLib.PreparersImage.Masks.Auto;
using RecognizerLib.PreparersImage.NotMask;

namespace Examples
{
    class Program
    {
        static void Main()
        {

            Example1();

            //Example2();

            //Example3();

            //Example4();

            //Example5();

            //----------- новые примеры ----------- 
            //Example6();

            //Example7();

            //Example8();

            //Example9();

            //Example10();

            //Example11();

            //Example12();

            //Example13();

            //Example14();
        }

        public static void Example1()
        {
            /*
             *  пример 1:
             *          -   в этом примере создаётся маска для изображения на основе черно белого изображения.
             *              Потом маска трансформируется с использованием закрытой морфологии.
             *              Отлавливаются только фигуры одинаковой яркости.
             *              Задача состоит в описании фигуры ( произвольной формы ) контуром ,который охватывает все точки фигуры.
             *              В результат идут контуры периметр ,которых больше 300
             */

            Recogniz recogniz = new Recogniz
            (
                new AutoGrayThreshold(),
                new ConvexHull(300),
                new TypicalFindContours()
            );

            CatchСontoursFromVideo video = new CatchСontoursFromVideo(recogniz);
            video.ISeeYou();
        }

        public static void Example2()
        {

            /*
             *  пример 2:
             *          -   в этом примере создаётся маска для изображения на основе черно белого изображения.
             *              Отлавливаются только фигуры одинаковой яркости.
             *              Задача состоит в описании фигуры ( произвольной формы ) контуром ,который охватывает все точки фигуры.
             *              В результат идут контуры периметр ,которых больше 300
             */

            Recogniz recogniz = new Recogniz
            (
                new GrayThreshold(),
                new ConvexHull(300),
                new TypicalFindContours()
            );

            CatchСontoursFromVideo video = new CatchСontoursFromVideo(recogniz);
            video.ISeeYou();
        }

        public static void Example3()
        {
            /*
             *  пример 3:
             *          -   в этом примере отлавливаются все контуры фигур игнорируя цвета.
             *              Чтобы избавиться от шума используют размытие по Гауссу
             *              Полученные контуры не упрощаются.
             *              Задача состоит в описании фигуры каким то контуром ( приблизительно ).
             */

            Recogniz recogniz = new Recogniz
            (
                new CannyBlur(),
                new WithoutApprox(50),
                new TypicalFindContours()
            );

            CatchСontoursFromVideo video = new CatchСontoursFromVideo(recogniz);
            video.ISeeYou();
        }

        public static void Example4()
        {
            /*
             * пример 4:
             *          -   в этом примере отлавливаются все контуры фигур игнорируя цвета.
             *              Чтобы избавиться от шума используют размытие по Гауссу
             *              Получентые контуры упрощаются.
             *              В результат попадают те ,у которых периметр которые больше 50.
             *              Задача состоит в описании фигуры каким то контуром ( приблизительно ).
             */

            Recogniz recogniz = new Recogniz
            (
                new CannyBlur(),
                new PolyDP(50),
                new TypicalFindContours()
            );

            CatchСontoursFromVideo video = new CatchСontoursFromVideo(recogniz);
            video.ISeeYou();
        }

        public static void Example5()
        {
            /*
             *  пример 5:
             *          -   в этом примере отлавливаются все контуры фигур игнорируя цвета.
             *              Получентые контуры упрощаются.
             *              В результат попадают те ,у которых периметр которые больше 50.
             *              Настройка маски происходит автоматически ( через меридиану ).
             *              Задача состаит в описании фигуры какимта контуром ( преблизительно ).
             */

            Recogniz recogniz = new Recogniz
            (
                new AutoCanny(),
                new PolyDP(50),
                new TypicalFindContours()
            );

            CatchСontoursFromVideo video = new CatchСontoursFromVideo(recogniz);
            video.ISeeYou();
        }

        public static void Example6()
        {
            /*
             *  пример 6:
             *          -   в этом примере отлавливаются контуры по освещенности.
             *              В результат попадают те у которых периметр больше 50.
             */

            Recogniz recogniz = new Recogniz
            (
                new AbsoluteDifferenceCloseMorphology(),
                new WithoutApprox(50),
                new TypicalFindContours()
            );

            CatchСontoursFromVideo video = new CatchСontoursFromVideo(recogniz);
            video.ISeeYou();
        }

        public static void Example7()
        {
            /*
             *  пример 7:
             *          находим бинарную маску изображения
             *          убираем все контуры периметр ,которых меньше 50 пикселей
             *          находим контуры простым способом
             */

            Recogniz recogniz = new Recogniz
            (
                new Binary(), 
                new WithoutApprox(50),
                new TypicalFindContours()
            );

            CatchСontoursFromVideo video = new CatchСontoursFromVideo(recogniz);
            video.ISeeYou();
        }

        public static void Example8()
        {
            /*
             *  пример 8:
             *             находим бинарную маску изображения
             *             берем очередь размером 25 масок
             *             уберем все контуры меньше 50 пикселей
             *             типичным образом находим контуры
             */

            Recogniz recogniz = new Recogniz
            (
                new DirtAdapter(new Binary(), 25), 
                new WithoutApprox(50),
                new TypicalFindContours()
            );

            CatchСontoursFromVideo video = new CatchСontoursFromVideo(recogniz);
            video.ISeeYou();
        }

        public static void Example9()
        {
            /*
             *  пример 9:
             *             берем очередь размером 50 масок
             *             маски находим с помощью порогового преобразования
             *             уберем все контуры меньше 50 пикселей
             *             типичным образом находим контуры
             */
            Recogniz recogniz = new Recogniz
            (
                new DirtAdapter(new AutoGrayThreshold(), 50),
                new WithoutApprox(50),
                new TypicalFindContours()
            );

            CatchСontoursFromVideo video = new CatchСontoursFromVideo(recogniz);
            video.ISeeYou();
        }

        public static void Example10()
        {
            /*
             *  пример 10:
             *             берем очередь размером 25 масок
             *             маски находим с помощью оператора Собеля
             *             уберем все контуры меньше 150 пикселей
             *             типичным образом находим контуры
             */

            Recogniz recogniz = new Recogniz
            (
                new DirtAdapter(new AutoCanny(), 25),
                new WithoutApprox(150),
                new TypicalFindContours()
            );

            CatchСontoursFromVideo video = new CatchСontoursFromVideo(recogniz);
            video.ISeeYou();
        }

        public static void Example11()
        {
            /*
            * пример 11:
            *               берем очередь размером 25 масок
            *               маски находим с помощью оператора Собеля по всем каналам изображения
            *               аппроксимируем контуры методом PolyDP
            *               уберем все контуры меньше 75 пикселей , а потом на получение контуры наложим прямоугольники
            *               находим контуры алгоритмом ApproxTC89L1
            */

            Recogniz recogniz = new Recogniz
            (
                new DirtAdapter(new AutoCannyOfBGR(), 25),
                new BoxPointsApprox(new PolyDP(75)), 
                new TypicalFindContours(ContourApproximationModes.ApproxTC89L1)
            );

            CatchСontoursFromVideo video = new CatchСontoursFromVideo(recogniz);
            video.ISeeYou();
        }

        public static void Example12()
        {
            /*
             *  пример 12:
             *             берем очередь размером 50 масок
             *             маски находим с помощью оператора Собеля по всем каналам изображения
             *             уберем все контуры меньше 350 пикселей , а потом на получение контуры наложим прямоугольники
             *             типичным образом находим контуры
             */

            Recogniz recogniz = new Recogniz
            (
                new DirtAdapter(new AutoCannyOfBGR(), 50),
                new BoxPointsApprox(new WithoutApprox(350)),
                new TypicalFindContours()
            );

            CatchСontoursFromVideo video = new CatchСontoursFromVideo(recogniz);
            video.ISeeYou();
        }

        public static void Example13()
        {
            /*
             *  пример 13:
             *             берем очередь размером 50 масок
             *             маски находим с помощью ConvexHull
             *             уберем все контуры меньше 350 пикселей , а потом на получение контуры наложим прямоугольники
             *             типичным образом находим контуры
             */

            Recogniz recogniz = new Recogniz
            (
                new DirtAdapter(new AutoCannyOfBGR(), 50),
                new BoxPointsApprox(new ConvexHull( 350)),
                new TypicalFindContours()
            );

            CatchСontoursFromVideo video = new CatchСontoursFromVideo(recogniz);
            video.ISeeYou();
        }

        public static void Example14()
        {
            /*
             *  пример 14:
             *             берем очередь размером 20 масок
             *             находим красный цвет на изображении
             *             уберем все контуры меньше 50 пикселей , а потом на получение контуры наложим прямоугольники
             *             типичным образом находим контуры
             */

            Recogniz recogniz = new Recogniz
            (

                new DirtAdapter(
                    new AutoMaskByHVS
                        (
                            new[]
                            {
                                new Tuple<Scalar, Scalar>(new Scalar(0, 120, 70),new Scalar(10, 255, 255) ),
                                new Tuple<Scalar, Scalar>(new Scalar(170, 120, 70),new Scalar(180, 255, 255) ),
                            }
                        )
                    ,20),
                new BoxPointsApprox(new WithoutApprox(50)),
                new TypicalFindContours()
            );

            CatchСontoursFromVideo video = new CatchСontoursFromVideo(recogniz);
            video.ISeeYou();
        }

    }
}
