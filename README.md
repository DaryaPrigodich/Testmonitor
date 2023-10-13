# Test automation project
## Application
https://www.testmonitor.com/

## Task
1. 	Реализовать фреймворк согласно индивидуальному заданию;
2. 	Создать public Git репозиторий содержащий финальный результат дипломной работы;
3. 	Реализовать следующий набор UI тестов:
   
 	  *a) 6 позитивных тестов:*
   	* 1 тест на проверку поля для ввода на граничные значения
    * 1 тест на проверку всплывающего сообщения
    * 1 тест на создание сущности
    * 1 тест на удаление сущности
    * 1 тест отображения диалогового окна
    * 1 тест на загрузку файла
    
    *б) 3 негативных теста:*
   	* 1 тест на использование некорректных данных
    * 1 тест на ввод данных превышающих допустимые
    * 1 тест воспроизводящий любой дефект
4. Реализовать следующий набор API тестов:

   *a) Get - 3 теста - NFE + 2 AFE*  
   *б) Post*
5. Подключить Allure для формирования отчета
6. Подключить Logger
7. Настроить CI/CD систему для запуска теста и отображения отчета

## GIT STRATEGY  
- ***master*** — main branch
- ***develop*** — the main development branch. Each commit to the develop branch is a result of a feature development completion. Each commit should be a result of a merge of merge request from a feature branch.
- ***feature*** — each new feature should reside in its own branch, which is created off of the latest develop version. When a feature is complete, it gets merged back into develop via merge request. After the feature branch is deleted.
## Детализация задания:
1. PageObject + NUnit
2. Основное задание
3. Jenkins
4. Доп задание “Создать данные для тестов используя API, данные взять из JSon”

