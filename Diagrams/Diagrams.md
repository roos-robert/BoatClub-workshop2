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
![alt tag](https://github.com/rr222cy/BoatClub-workshop2/blob/master/Diagrams/Requirement2.1.png)
![alt tag](https://github.com/rr222cy/BoatClub-workshop2/blob/master/Diagrams/Requirement2.2.png)

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
RunBoatClub->+Console: RunBoatClub()  

loop main menu  
Console->+MainMenuView: InitMenu()  
MainMenuView->MainMenuView: ViewMenu()  

MainMenuView->+UserView: HandleUser()  
UserView->+User: HandleUser()  
User->+BoatClubRepository: HandleUser()  
User->+User: HandleUser()  
end  


![alt tag](https://github.com/rr222cy/BoatClub-workshop2/blob/master/Diagrams/Requirement4.png)
## Diagram for requirement 5
RunBoatClub->+Console: RunBoatClub()  

loop main menu  
Console->+MainMenuView: InitMenu()  
MainMenuView->MainMenuView: ViewMenu()  
end  

MainMenuView->+UserView: ShowUser()  
UserView->+User: ShowUser()  
User->+BoatClubRepository: GetDocument()  
User->+User: ShowUsersSimple()  

![alt tag](https://github.com/rr222cy/BoatClub-workshop2/blob/master/Diagrams/Requirement5.png)
## Diagram for requirement 6

![alt tag](https://github.com/rr222cy/BoatClub-workshop2/blob/master/Diagrams/Requirement6.png)
## Diagram for requirement 7
RunBoatClub->+Console: RunBoatClub()  

loop main menu  
Console->+MainMenuView: InitMenu()  
MainMenuView->MainMenuView: ViewMenu()  
end  

MainMenuView->+BoatView: BoatMenu()  

loop handle boat menu  
BoatView->+BoatView: InitMenu()  
BoatView->BoatView: ViewMenu()  
end  

BoatView->+Boat: RemoveBoat()  
Boat->+BoatClubRepository: GetDocument()  
Boat->+Boat: RemoveBoat()  

![alt tag](https://github.com/rr222cy/BoatClub-workshop2/blob/master/Diagrams/Requirement7.png)
## Diagram for requirement 8
RunBoatClub->+Console: RunBoatClub()  

loop main menu  
Console->+MainMenuView: InitMenu()  
MainMenuView->MainMenuView: ViewMenu()  
end  

MainMenuView->+BoatView: BoatMenu()  

loop handle boat menu  
BoatView->+BoatView: InitMenu()  
BoatView->BoatView: ViewMenu()  
end  

BoatView->+Boat: HandleBoat()  
Boat->+BoatClubRepository: GetDocument()  
Boat->+Boat: HandleBoat()  

![alt tag](https://github.com/rr222cy/BoatClub-workshop2/blob/master/Diagrams/Requirement8.png)