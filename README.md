# TestMindbox
Test task for Mindbox 

### Task 1
1) Для реализации и добавления новых фигур требуется реализовать интерфейс IBaseFigure. Также для реализации новых вариантов создания существующих фигур осталась возможность реализовать перегрузку конструктора и добавить новые способы создания, переиспользовав часть логики расчётов.
3) В solution есть проект с юнит тестами на NUnit, покрывающими основные кейсы использования классов
4) Вычисление в compile time зависит от компиляции в ILcode, что не позволяет реализовывать расчёт в компиляции,так как значения в классах задаются в Runtime. Как вариант использовать static методы и классы, но предположительно - это не является ожидаемым поведением
5) Проверка на прямоугольность реализована как отдельный метод, так как может быть использована отдельно для создания отдельной логики, поэтому была отделена

Комментарии к 1-му заданию
Можно было перенести метод расчёта площади в конструктор, тем самыс облегчив класс, но при этом есть риск потерять в гибкости, поэтому все логические части были вынесены в методы. Также тесты можно объединить в единый параметризованный тест, но на мой взгляд есть смысл разделить логику для проверки конкретных кейсов

### Task 2

Предположим, что схема БД выглядит следующим образом исходя из описания

1) Таблица product с полями id, name
2) Таблица category с полями id, name
3) Таблица productCategory с полями id, product_id, category_id

Исходя из описания между продуктами и категорией продукта есть связь многие-ко-многим, для чего появляется промежуточная таблица productCategory
Для того, чтобы сделать запрос с выводом имён всех продуктов требуется сделать LEFT JOIN запрос, который включает всё множество, присоединённое слева, т.е. всю таблицу products

Тогда запрос будет выглядеть следующим образом:

SELECT product.name, category.name FROM product\
LEFT JOIN productCategory ON productCategory.product_id = product.id\
JOIN category ON productCategory.category_id = category.id