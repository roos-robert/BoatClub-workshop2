# Diagrams for Workshop 2
The diagrams are given both in code for http://websequencediagrams.com and in .png images.
The requirements refered to can be found at: https://coursepress.lnu.se/kurs/objektorienterad-analys-och-design-med-uml/workshops/workshop-2-design/

## Diagram for requirement 1
RunBoatClub->+Console: RunBoatClub()  

loop main menu  
Console->+MainMenuView: InitMenu()  
MainMenuView->MainMenuView: ViewMenu()  
end  

MainMenuView->+UserView: AddUser()  
UserView->+User: AddUser()  
User->+BoatClubRepository: GetDocument()  
User->+User: AddUser()  

![alt tag](https://github.com/rr222cy/BoatClub-workshop2/blob/master/Diagrams/Requirement1.png)

## Diagram for requirement 2

## Diagram for requirement 3
RunBoatClub->+Console: RunBoatClub()  

loop main menu  
Console->+MainMenuView: InitMenu()  
MainMenuView->MainMenuView: ViewMenu()  
end  

MainMenuView->+UserView: RemoveUser()  
UserView->+User: RemoveUser()  
User->+BoatClubRepository: GetDocument()  
User->+User: RemoveUser()  

![alt tag](https://github.com/rr222cy/BoatClub-workshop2/blob/master/Diagrams/Requirement3.png)
## Diagram for requirement 4

## Diagram for requirement 5

## Diagram for requirement 6

## Diagram for requirement 7

## Diagram for requirement 8