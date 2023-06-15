Ã
dC:\Users\mike\Desktop\Calidad_ofline\PRUEBAS-MADERERA\SISTEMA\CapaVistaWeb\App_Start\BundleConfig.cs
	namespace 	
MadereraCarocho
 
{ 
public 

class 
BundleConfig 
{ 
public 
static 
void 
RegisterBundles *
(* +
BundleCollection+ ;
bundles< C
)C D
{		 	
bundles

 
.

 
Add

 
(

 
new

 
ScriptBundle

 (
(

( )
$str

) ;
)

; <
.

< =
Include

= D
(

D E
$str 7
)7 8
)8 9
;9 :
bundles 
. 
Add 
( 
new 
ScriptBundle (
(( )
$str) >
)> ?
.? @
Include@ G
(G H
$str 4
)4 5
)5 6
;6 7
bundles 
. 
Add 
( 
new 
ScriptBundle (
(( )
$str) >
)> ?
.? @
Include@ G
(G H
$str /
)/ 0
)0 1
;1 2
bundles 
. 
Add 
( 
new 
ScriptBundle (
(( )
$str) >
)> ?
.? @
Include@ G
(G H
$str .
). /
)/ 0
;0 1
bundles 
. 
Add 
( 
new 
StyleBundle '
(' (
$str( 7
)7 8
.8 9
Include9 @
(@ A
$str /
,/ 0
$str *
)* +
)+ ,
;, -
} 	
} 
} ñ
dC:\Users\mike\Desktop\Calidad_ofline\PRUEBAS-MADERERA\SISTEMA\CapaVistaWeb\App_Start\FilterConfig.cs
	namespace 	
MadereraCarocho
 
{ 
public 

class 
FilterConfig 
{ 
public 
static 
void !
RegisterGlobalFilters 0
(0 1"
GlobalFilterCollection1 G
filtersH O
)O P
{ 	
filters		 
.		 
Add		 
(		 
new		  
HandleErrorAttribute		 0
(		0 1
)		1 2
)		2 3
;		3 4
}

 	
} 
} Ù
cC:\Users\mike\Desktop\Calidad_ofline\PRUEBAS-MADERERA\SISTEMA\CapaVistaWeb\App_Start\RouteConfig.cs
	namespace 	
MadereraCarocho
 
{ 
public 

class 
RouteConfig 
{ 
public 
static 
void 
RegisterRoutes )
() *
RouteCollection* 9
routes: @
)@ A
{		 	
routes

 
.

 
IgnoreRoute

 
(

 
$str

 ;
)

; <
;

< =
routes 
. 
MapRoute 
( 
name 
: 
$str 
,  
url 
: 
$str 1
,1 2
defaults 
: 
new 
{ 

controller  *
=+ ,
$str- 3
,3 4
action5 ;
=< =
$str> E
,E F
idG I
=J K
UrlParameterL X
.X Y
OptionalY a
}b c
) 
; 
} 	
} 
} Á&
tC:\Users\mike\Desktop\Calidad_ofline\PRUEBAS-MADERERA\SISTEMA\CapaVistaWeb\Controllers\TemporaryProductController.cs
	namespace		 	
MadereraCarocho		
 
.		 
Controllers		 %
{

 
[ 
	Authorize 
] 
public 

class &
TemporaryProductController +
:, -

Controller. 8
{  
LogTemporaryProducts 
TemporaryPservice .
;. /
public &
TemporaryProductController )
() *
)* +
{ 	
TemporaryPservice 
= 
new  # 
LogTemporaryProducts$ 8
(8 9
new9 < 
DatTemporaryProducts= Q
(Q R
)R S
)S T
;T U
} 	
[ 	
PermisosRol	 
( 
entRol 
. 
Administrador )
)) *
]* +
[ 	
HttpGet	 
] 
public 
ActionResult 
ListarTempProduct -
(- .
). /
{ 	

EntUsuario 
usuario 
=  
new! $

EntUsuario% /
(/ 0
)0 1
;1 2
usuario 
= 
Session 
[ 
$str '
]' (
as) +

EntUsuario, 6
;6 7
return 
View 
( 
TemporaryPservice )
.) *$
MostrarTemporaryProducts* B
(B C
usuarioC J
.J K
	IdUsuarioK T
)T U
)U V
;V W
} 	
[   	
PermisosRol  	 
(   
entRol   
.   
Cliente   #
)  # $
]  $ %
[!! 	
HttpGet!!	 
]!! 
public"" 
ActionResult"" #
ListarTempProductClient"" 3
(""3 4
)""4 5
{## 	

EntUsuario$$ 
usuario$$ 
=$$  
new$$! $

EntUsuario$$% /
($$/ 0
)$$0 1
;$$1 2
usuario%% 
=%% 
Session%% 
[%% 
$str%% '
]%%' (
as%%) +

EntUsuario%%, 6
;%%6 7
return&& 
View&& 
(&& 
TemporaryPservice&& )
.&&) *'
MostrarTemporaryProductsCli&&* E
(&&E F
usuario&&F M
.&&M N
	IdUsuario&&N W
)&&W X
)&&X Y
;&&Y Z
}'' 	
[)) 	
PermisosRol))	 
()) 
entRol)) 
.)) 
Administrador)) )
)))) *
]))* +
[** 	
HttpGet**	 
]** 
public++ 
ActionResult++ 
EliminarTempPrduct++ .
(++. /
int++/ 2
idtemp++3 9
)++9 :
{,, 	
try-- 
{.. 
bool// 
elimina// 
=// 
TemporaryPservice// 0
.//0 1%
EliminarTemporaryProducts//1 J
(//J K
idtemp//K Q
)//Q R
;//R S
}00 
catch11 
(11 
	Exception11 
ex11 
)11  
{22 
return44 
RedirectToAction44 '
(44' (
$str44( /
,44/ 0
$str441 7
,447 8
new449 <
{44= >
mesjExeption44? K
=44L M
ex44N P
.44P Q
Message44Q X
}44Y Z
)44Z [
;44[ \
}55 
return66 
RedirectToAction66 #
(66# $
$str66$ 7
)667 8
;668 9
}77 	
[99 	
PermisosRol99	 
(99 
entRol99 
.99 
Cliente99 #
)99# $
]99$ %
[:: 	
HttpGet::	 
]:: 
public;; 
ActionResult;; $
EliminarTempPrductClient;; 4
(;;4 5
int;;5 8
idtemp;;9 ?
);;? @
{<< 	
try== 
{>> 
bool?? 
elimina?? 
=?? 
TemporaryPservice?? 0
.??0 1%
EliminarTemporaryProducts??1 J
(??J K
idtemp??K Q
)??Q R
;??R S
}@@ 
catchAA 
(AA 
	ExceptionAA 
exAA 
)AA  
{BB 
returnDD 
RedirectToActionDD '
(DD' (
$strDD( /
,DD/ 0
$strDD1 7
,DD7 8
newDD9 <
{DD= >
mesjExeptionDD? K
=DDL M
exDDN P
.DDP Q
MessageDDQ X
}DDY Z
)DDZ [
;DD[ \
}EE 
returnFF 
RedirectToActionFF #
(FF# $
$strFF$ =
)FF= >
;FF> ?
}GG 	
}II 
}JJ ¥2
kC:\Users\mike\Desktop\Calidad_ofline\PRUEBAS-MADERERA\SISTEMA\CapaVistaWeb\Controllers\UsuarioController.cs
	namespace

 	
MadereraCarocho


 
.

 
Controllers

 %
{ 
[ 
PermisosRol 
( 
entRol 
. 
Administrador %
)% &
]& '
[ 
	Authorize 
] 
public 

class 
UsuarioController "
:# $

Controller% /
{ 

LogUsuario 
Usuarioservice !
;! "
	LogUbigeo 
Ubigeoservice 
;  
public 
UsuarioController  
(  !
)! "
{ 	
Usuarioservice 
= 
new  

LogUsuario! +
(+ ,
new, /

DatUsuario0 :
(: ;
); <
)< =
;= >
Ubigeoservice 
= 
new 
	LogUbigeo  )
() *
new* -
	DatUbigeo. 7
(7 8
)8 9
)9 :
;: ;
} 	
public 
ActionResult 
ListarClientes *
(* +
string+ 1
dato2 6
)6 7
{ 	
List 
< 

EntUsuario 
> 
lista "
;" #
if 
( 
! 
String 
. 
IsNullOrEmpty %
(% &
dato& *
)* +
)+ ,
{ 
lista 
= 
Usuarioservice &
.& '
BuscarClientes' 5
(5 6
dato6 :
): ;
;; <
}   
else!! 
{"" 
lista## 
=## 
Usuarioservice## &
.##& '
ListarClientes##' 5
(##5 6
)##6 7
;##7 8
}$$ 
List%% 
<%% 
	EntUbigeo%% 
>%% 
listaUbigeo%% '
=%%( )
Ubigeoservice%%* 7
.%%7 8
ListarDistrito%%8 F
(%%F G
)%%G H
;%%H I
var&& 
lsUbigeo&& 
=&& 
new&& 

SelectList&& )
(&&) *
listaUbigeo&&* 5
,&&5 6
$str&&7 A
,&&A B
$str&&C M
)&&M N
;&&N O
ViewBag(( 
.(( 
lista(( 
=(( 
lista(( !
;((! "
ViewBag)) 
.)) 
listaUbigeo)) 
=))  !
lsUbigeo))" *
;))* +
ViewBag** 
.** 
Error** 
=** 
$str** &
;**& '
return++ 
View++ 
(++ 
lista++ 
)++ 
;++ 
},, 	
[-- 	
HttpGet--	 
]-- 
public.. 
ActionResult.. 
EliminarClientes.. ,
(.., -
int..- 0
idc..1 4
)..4 5
{// 	
try00 
{11 
bool22 
elimina22 
=22 
Usuarioservice22 -
.22- .
EliminarUsuarios22. >
(22> ?
idc22? B
)22B C
;22C D
ViewBag44 
.44 
Error44 
=44 
$str44  A
;44A B
}66 
catch77 
(77 
	Exception77 
ex77 
)77  
{88 
ViewBag99 
.99 
Error99 
=99 
$str99  5
;995 6
return:: 
RedirectToAction:: '
(::' (
$str::( 8
,::8 9
new::: =
{::> ?
mesjExeption::@ L
=::M N
ex::O Q
.::Q R
Message::R Y
}::Z [
)::[ \
;::\ ]
};; 
return<< 
RedirectToAction<< #
(<<# $
$str<<$ 4
)<<4 5
;<<5 6
}== 	
[?? 	
HttpGet??	 
]?? 
public@@ 
ActionResult@@ 
EditarCliente@@ )
(@@) *
int@@* -
c@@. /
)@@/ 0
{AA 	
varBB 
usuarioBB 
=BB 
UsuarioserviceBB (
.BB( )
BuscarIdUsuarioBB) 8
(BB8 9
cBB9 :
)BB: ;
;BB; <
ViewBagCC 
.CC 
OldRollCC 
=CC 
usuarioCC %
.CC% &
RollCC& *
.CC* +
DescripcionCC+ 6
;CC6 7
ViewBagDD 
.DD 
	OldUbigeoDD 
=DD 
usuarioDD  '
.DD' (
UbigeoDD( .
.DD. /
DepartamentoDD/ ;
+DD< =
$strDD> B
+DDC D
usuarioDDE L
.DDL M
UbigeoDDM S
.DDS T
	ProvinciaDDT ]
+DD^ _
$strDD` d
+DDe f
usuarioDDg n
.DDn o
UbigeoDDo u
.DDu v
DistritoDDv ~
;DD~ 
returnEE 
ViewEE 
(EE 
usuarioEE 
)EE  
;EE  !
}FF 	
[HH 	
HttpPostHH	 
]HH 
publicII 
ActionResultII 
EditarClienteII )
(II) *

EntUsuarioII* 4
uII5 6
)II6 7
{JJ 	
tryKK 
{LL 
BooleanMM 
editaMM 
=MM 
UsuarioserviceMM  .
.MM. /
EditarClienteMM/ <
(MM< =
uMM= >
)MM> ?
;MM? @
ifNN 
(NN 
editaNN 
)NN 
{OO 
returnPP 
RedirectToActionPP +
(PP+ ,
$strPP, <
)PP< =
;PP= >
}QQ 
elseRR 
{SS 
returnTT 
ViewTT 
(TT  
uTT  !
)TT! "
;TT" #
}UU 
}VV 
catchWW 
(WW  
ApplicationExceptionWW '
exWW( *
)WW* +
{XX 
returnYY 
RedirectToActionYY '
(YY' (
$strYY( 8
,YY8 9
newYY: =
{YY> ?
mesjExceptioYY@ L
=YYM N
exYYO Q
.YYQ R
MessageYYR Y
}YYZ [
)YY[ \
;YY\ ]
}ZZ 
}[[ 	
}hh 
}ii Á<
jC:\Users\mike\Desktop\Calidad_ofline\PRUEBAS-MADERERA\SISTEMA\CapaVistaWeb\Controllers\CompraController.cs
	namespace

 	
MadereraCarocho


 
.

 
Controllers

 %
{ 
[ 
	Authorize 
] 
[ 
PermisosRol 
( 
entRol 
. 
Administrador %
)% &
]& '
public 

class 
CompraController !
:" #

Controller$ .
{ 
	LogCompra 
CompraService 
;  
LogDetCompra 
DetCompraService %
;% &
LogVenta 
Ventaservice 
;  
LogTemporaryProducts 
TemporaryPservice .
;. /
public 
CompraController 
(  
)  !
{ 	
CompraService 
= 
new 
	LogCompra  )
() *
new* -
	DatCompra. 7
(7 8
)8 9
)9 :
;: ;
DetCompraService 
= 
new "
LogDetCompra# /
(/ 0
new0 3
DatDetCompra4 @
(@ A
)A B
)B C
;C D
TemporaryPservice 
= 
new  # 
LogTemporaryProducts$ 8
(8 9
new9 < 
DatTemporaryProducts= Q
(Q R
)R S
)S T
;T U
Ventaservice 
= 
new 
LogVenta '
(' (
new( +
DatVenta, 4
(4 5
)5 6
)6 7
;7 8
} 	
public 
ActionResult 
ListarCompra (
(( )
)) *
{   	
_!! 
=!! 
new!! 

EntUsuario!! 
(!! 
)!!  
;!!  !

EntUsuario"" 
usuario"" 
=""  
Session""! (
[""( )
$str"") 2
]""2 3
as""4 6

EntUsuario""7 A
;""A B
return## 
View## 
(## 
CompraService## %
.##% &
ListarCompra##& 2
(##2 3
usuario##3 :
.##: ;
	IdUsuario##; D
)##D E
)##E F
;##F G
}$$ 	
public&& 
ActionResult&& !
ListarTodasLasCompras&& 1
(&&1 2
)&&2 3
{'' 	
return(( 
View(( 
((( 
CompraService(( %
.((% &!
ListartodasLasCompras((& ;
(((; <
)((< =
)((= >
;((> ?
})) 	
public++ 
ActionResult++  
ListarTodasLasVentas++ 0
(++0 1
)++1 2
{,, 	
return-- 
View-- 
(-- 
Ventaservice-- $
.--$ %
ListarTodasLasVenta--% 8
(--8 9
)--9 :
)--: ;
;--; <
}.. 	
public00 
ActionResult00 
ConfirmarCompra00 +
(00+ ,
)00, -
{11 	
try22 
{33 

EntUsuario55 
usuario55 "
=55" #
new55# &

EntUsuario55' 1
(551 2
)552 3
;553 4
usuario66 
=66 
Session66 !
[66! "
$str66" +
]66+ ,
as66- /

EntUsuario660 :
;66: ;
List88 
<88  
EntTemporaryProducts88 )
>88) *
list88+ /
=880 1
new882 5
List886 :
<88: ; 
EntTemporaryProducts88; O
>88O P
(88P Q
)88Q R
;88R S
list99 
=99 
TemporaryPservice99 (
.99( )$
MostrarTemporaryProducts99) A
(99A B
usuario99B I
.99I J
	IdUsuario99J S
)99S T
;99T U
double<< 
total<< 
=<< 
$num<<  
;<<  !
for== 
(== 
int== 
i== 
=== 
$num== 
;== 
i==  !
<==" #
list==# '
.==' (
Count==( -
(==- .
)==. /
;==/ 0
i==1 2
++==2 4
)==4 5
{>> 
total?? 
+=?? 
list??  
[??  !
i??! "
]??" #
.??# $
Subtotal??$ ,
;??, -
}@@ 
	EntCompraBB 
PedidoBB  
=BB! "
newBB# &
	EntCompraBB' 0
{CC 
UsuarioDD 
=DD 
usuarioDD %
,DD% &
TotalEE 
=EE 
totalEE !
}FF 
;FF 
intII 
idCompraII 
=II 
CompraServiceII ,
.II, -
CrearCompraII- 8
(II8 9
PedidoII9 ?
)II? @
;II@ A
PedidoKK 
.KK 
IdCompraKK 
=KK  !
idCompraKK" *
;KK* +
EntDetCompraMM 
detMM  
=MM! "
newMM# &
EntDetCompraMM' 3
(MM3 4
)MM4 5
;MM5 6
forNN 
(NN 
intNN 
iNN 
=NN 
$numNN 
;NN 
iNN  !
<NN" #
listNN# '
.NN' (
CountNN( -
;NN- .
iNN/ 0
++NN0 2
)NN2 3
{OO 
detPP 
.PP 
CompraPP 
=PP  
PedidoPP! '
;PP' (
detQQ 
.QQ 
ProveedorProductoQQ )
=QQ* +
newQQ, / 
EntProveedorProductoQQ0 D
{RR 
	ProveedorSS !
=SS" #
newSS$ '
EntProveedorSS( 4
{TT 
IdProveedorUU '
=UU( )
listUU* .
[UU. /
iUU/ 0
]UU0 1
.UU1 2
ProveedorProductoUU2 C
.UUC D
	ProveedorUUD M
.UUM N
IdProveedorUUN Y
}VV 
,VV 
ProductoWW  
=WW  !
newWW! $
EntProductoWW% 0
{XX 

IdProductoYY &
=YY' (
listYY) -
[YY- .
iYY. /
]YY/ 0
.YY0 1
ProveedorProductoYY1 B
.YYB C
ProductoYYC K
.YYK L

IdProductoYYL V
}ZZ 
}[[ 
;[[ 
det\\ 
.\\ 
Cantidad\\  
=\\! "
list\\# '
[\\' (
i\\( )
]\\) *
.\\* +
Cantidad\\+ 3
;\\3 4
det]] 
.]] 
Subtotal]]  
=]]! "
list]]# '
[]]' (
i]]( )
]]]) *
.]]* +
Subtotal]]+ 3
;]]3 4
DetCompraService__ $
.__$ %
CrearDetCompra__% 3
(__3 4
det__4 7
)__7 8
;__8 9
}`` 
returnaa 
RedirectToActionaa '
(aa' (
$straa( 6
)aa6 7
;aa7 8
}cc 
catchdd 
{ee 
returnff 
RedirectToActionff '
(ff' (
$strff( /
,ff/ 0
$strff0 6
)ff6 7
;ff7 8
}hh 
}ii 	
publickk 
ActionResultkk  
MostrarDetalleComprakk 0
(kk0 1
intkk2 5
idcomprakk6 >
)kk> ?
{ll 	
returnmm 
Viewmm 
(mm 
DetCompraServicemm (
.mm( )"
MostrarDetalleCompraIdmm) ?
(mm? @
idcompramm@ H
)mmH I
)mmI J
;mmJ K
}nn 	
}oo 
}pp ∏ß
hC:\Users\mike\Desktop\Calidad_ofline\PRUEBAS-MADERERA\SISTEMA\CapaVistaWeb\Controllers\HomeController.cs
	namespace 	
MadereraCarocho
 
. 
Controllers %
{ 
public 

class 
HomeController 
:  !

Controller" ,
{ 

LogUsuario 
Usuarioservice !
;! "
LogProducto 
Productoservice #
;# $
	LogUbigeo 
Ubigeoservice 
;   
LogTemporaryProducts 
TemporaryPservice .
;. /
ValidatorHelper 
validatorHelper '
=( )
new) ,
ValidatorHelper- <
(< =
)= >
;> ?
public 
HomeController 
( 
) 
{ 	
Usuarioservice 
= 
new  

LogUsuario! +
(+ ,
new, /

DatUsuario0 :
(: ;
); <
)< =
;= >
Productoservice 
= 
new !
LogProducto" -
(- .
new. 1
DatProducto2 =
(= >
)> ?
)? @
;@ A
Ubigeoservice 
= 
new 
	LogUbigeo  )
() *
new* -
	DatUbigeo. 7
(7 8
)8 9
)9 :
;: ;
TemporaryPservice 
= 
new  # 
LogTemporaryProducts$ 8
(8 9
new9 < 
DatTemporaryProducts= Q
(Q R
)R S
)S T
;T U
} 	
public   
ActionResult   
Index   !
(  ! "
string  " (
dato  ) -
)  - .
{!! 	
List"" 
<"" 
EntProducto"" 
>"" 
lista"" #
;""# $
if## 
(## 
string## 
.## 
IsNullOrEmpty## $
(##$ %
dato##% )
)##) *
)##* +
lista$$ 
=$$ 
Productoservice$$ '
.$$' (
ListarProducto$$( 6
($$6 7
)$$7 8
;$$8 9
else%% 
lista&& 
=&& 
Productoservice&& '
.&&' (
BuscarProducto&&( 6
(&&6 7
dato&&7 ;
)&&; <
;&&< =
return(( 
View(( 
((( 
lista(( 
)(( 
;(( 
})) 	
public** 
ActionResult** 
SinPermisos** '
(**' (
)**( )
{++ 	
ViewBag,, 
.,, 
Message,, 
=,, 
$str,, R
;,,R S
return-- 
View-- 
(-- 
)-- 
;-- 
}.. 	
public// 
ActionResult// 
Error// !
(//! "
)//" #
{00 	
return11 
View11 
(11 
)11 
;11 
}22 	
[33 	
HttpGet33	 
]33 
public44 
ActionResult44 
Login44 !
(44! "
)44" #
{55 	
return66 
View66 
(66 
)66 
;66 
}77 	
public88 
ActionResult88 
Registro88 $
(88$ %
)88% &
{99 	
List:: 
<:: 
	EntUbigeo:: 
>:: 
listaUbigeo:: '
=::( )
Ubigeoservice::* 7
.::7 8
ListarDistrito::8 F
(::F G
)::G H
;::H I
var;; 
lsUbigeo;; 
=;; 
new;; 

SelectList;; )
(;;) *
listaUbigeo;;* 5
,;;5 6
$str;;7 A
,;;A B
$str;;C M
);;M N
;;;N O
ViewBag<< 
.<< 
listaUbigeo<< 
=<<  !
lsUbigeo<<" *
;<<* +
return== 
View== 
(== 
)== 
;== 
}>> 	
[AA 	
HttpPostAA	 
]AA 
publicBB 
ActionResultBB 
SingUpBB "
(BB" #
stringBB# )
nombreBB* 0
,BB0 1
stringBB2 8
usernameBB9 A
,BBA B
stringBBC I
emailBBJ O
,BBO P
stringBBQ W
passwordBBX `
,BB` a
FormCollectionBBb p
ubiBBq t
)BBt u
{CC 	
boolDD 

isNonEmptyDD 
=DD 
validatorHelperDD -
.DD- .
ValidateNonEmptyDD. >
(DD> ?
nombreDD? E
,DDE F
usernameDDF N
,DDN O
emailDDO T
,DDT U
passwordDDU ]
)DD] ^
;DD^ _
tryEE 
{FF 
ifHH 
(HH 

isNonEmptyHH 
)HH 
{II 

EntUsuarioJJ 
cJJ  
=JJ! "
newJJ# &

EntUsuarioJJ' 1
{KK 
RazonSocialLL #
=LL$ %
nombreLL& ,
,LL, -
UserNameMM  
=MM! "
usernameMM# +
,MM+ ,
CorreoNN 
=NN  
emailNN! &
,NN& '
PassOO 
=OO 
	EncriptarOO (
.OO( )
	GetSHA256OO) 2
(OO2 3
passwordOO3 ;
)OO; <
,OO< =
RollPP 
=PP 
newPP "
entRollPP# *
{QQ 
IdRollRR "
=RR# $
$numRR% &
}SS 
,SS 
UbigeoTT 
=TT  
newTT! $
	EntUbigeoTT% .
{UU 
IdUbigeoVV $
=VV% &
ubiVV' *
[VV* +
$strVV+ 3
]VV3 4
.VV4 5
ToStringVV5 =
(VV= >
)VV> ?
}WW 
}XX 
;XX 
boolYY 
creadoYY 
=YY  !
UsuarioserviceYY" 0
.YY0 1
CrearClientesYY1 >
(YY> ?
cYY? @
)YY@ A
;YYA B
}ZZ 
}[[ 
catch\\ 
(\\ 
	Exception\\ 
ex\\ 
)\\  
{]] 
TempData^^ 
[^^ 
$str^^  
]^^  !
=^^" #
ex^^$ &
.^^& '
Message^^' .
;^^. /
return__ 
RedirectToAction__ '
(__' (
$str__( /
)__/ 0
;__0 1
}`` 
returnaa 
RedirectToActionaa #
(aa# $
$straa$ +
)aa+ ,
;aa, -
}bb 	
[cc 	
HttpPostcc	 
]cc 
publicdd 
ActionResultdd 
VerificarAccesodd +
(dd+ ,
stringdd, 2
userdd3 7
,dd7 8
stringdd9 ?
passdd@ D
)ddD E
{ee 	
trygg 
{hh 
ifii 
(ii 
!ii 
(ii 
stringii 
.ii 
IsNullOrEmptyii *
(ii* +
userii+ /
)ii/ 0
||ii1 3
stringii4 :
.ii: ;
IsNullOrEmptyii; H
(iiH I
passiiI M
)iiM N
)iiN O
)iiO P
{jj 

EntUsuariokk 

objUsuariokk )
=kk* +
Usuarioservicekk, :
.kk: ;
IniciarSesionkk; H
(kkH I
userkkI M
,kkM N
passkkO S
)kkS T
;kkT U
ifll 
(ll 

objUsuarioll "
!=ll# %
nullll& *
)ll* +
{mm 
FormsAuthenticationnn +
.nn+ ,
SetAuthCookienn, 9
(nn9 :

objUsuarionn: D
.nnD E
CorreonnE K
,nnK L
falsennM R
)nnR S
;nnS T
Sessionoo 
[oo  
$stroo  )
]oo) *
=oo+ ,

objUsuariooo- 7
;oo7 8
ifpp 
(pp 

objUsuariopp &
.pp& '
Rolpp' *
==pp+ -
entRolpp. 4
.pp4 5
Administradorpp5 B
)ppB C
{qq 
returnrr "
RedirectToActionrr# 3
(rr3 4
$strrr4 ;
)rr; <
;rr< =
}ss 
elsett 
{uu 
ifvv 
(vv  

objUsuariovv  *
.vv* +
Rolvv+ .
==vv/ 1
entRolvv2 8
.vv8 9
Clientevv9 @
)vv@ A
{ww 
returnxx  &
RedirectToActionxx' 7
(xx7 8
$strxx8 A
)xxA B
;xxB C
}yy 
}zz 
}{{ 
}|| 
}
ÄÄ 
catch
ÅÅ 
(
ÅÅ 
	Exception
ÅÅ 
ex
ÅÅ 
)
ÅÅ 
{
ÇÇ 
TempData
ÉÉ 
[
ÉÉ 
$str
ÉÉ  
]
ÉÉ  !
=
ÉÉ! "
ex
ÉÉ# %
.
ÉÉ% &
Message
ÉÉ& -
;
ÉÉ- .
TempData
ÑÑ 
[
ÑÑ 
$str
ÑÑ "
]
ÑÑ" #
=
ÑÑ$ %
$str
ÑÑ& @
;
ÑÑ@ A
return
ÖÖ 
RedirectToAction
ÖÖ '
(
ÖÖ' (
$str
ÖÖ( /
)
ÖÖ/ 0
;
ÖÖ0 1
}
áá 
return
àà 
RedirectToAction
àà #
(
àà# $
$str
àà$ +
)
àà+ ,
;
àà, -
}
ââ 	
public
ää 
ActionResult
ää 
CerrarSesion
ää (
(
ää( )
)
ää) *
{
ãã 	
Session
åå 
[
åå 
$str
åå 
]
åå 
=
åå  
null
åå! %
;
åå% &!
FormsAuthentication
çç 
.
çç  
SignOut
çç  '
(
çç' (
)
çç( )
;
çç) *
return
éé 
RedirectToAction
éé #
(
éé# $
$str
éé$ +
)
éé+ ,
;
éé, -
}
èè 	
[
ìì 	
PermisosRol
ìì	 
(
ìì 
entRol
ìì 
.
ìì 
Cliente
ìì #
)
ìì# $
]
ìì$ %
[
îî 	
	Authorize
îî	 
]
îî 
public
ïï 
ActionResult
ïï 
Cliente
ïï #
(
ïï# $
string
ïï$ *
dato
ïï+ /
)
ïï/ 0
{
ññ 	
if
óó 
(
óó 
Session
óó 
[
óó 
$str
óó !
]
óó! "
!=
óó# %
null
óó& *
)
óó* +
{
òò 
List
ôô 
<
ôô 
EntProducto
ôô  
>
ôô  !
lista
ôô" '
;
ôô' (
if
öö 
(
öö 
string
öö 
.
öö 
IsNullOrEmpty
öö (
(
öö( )
dato
öö) -
)
öö- .
)
öö. /
lista
õõ 
=
õõ 
Productoservice
õõ +
.
õõ+ ,
ListarProducto
õõ, :
(
õõ: ;
)
õõ; <
;
õõ< =
else
úú 
lista
ùù 
=
ùù 
Productoservice
ùù +
.
ùù+ ,
BuscarProducto
ùù, :
(
ùù: ;
dato
ùù; ?
)
ùù? @
;
ùù@ A
return
ûû 
View
ûû 
(
ûû 
lista
ûû !
)
ûû! "
;
ûû" #
}
üü 
return
†† 
RedirectToAction
†† #
(
††# $
$str
††$ +
)
††+ ,
;
††, -
}
°° 	
[
££ 	
PermisosRol
££	 
(
££ 
entRol
££ 
.
££ 
Cliente
££ #
)
££# $
]
££$ %
[
§§ 	
	Authorize
§§	 
]
§§ 
[
•• 	
HttpGet
••	 
]
•• 
public
¶¶ 
ActionResult
¶¶  
EditarDatosCliente
¶¶ .
(
¶¶. /
)
¶¶/ 0
{
ßß 	
var
®® 
usuario
®® 
=
®® 
Session
®® !
[
®®! "
$str
®®" +
]
®®+ ,
as
®®- /

EntUsuario
®®0 :
;
®®: ;
ViewBag
©© 
.
©© 
listaUbigeo
©© 
=
©©  !
new
©©" %

SelectList
©©& 0
(
©©0 1
Ubigeoservice
©©1 >
.
©©> ?
ListarDistrito
©©? M
(
©©M N
)
©©N O
,
©©O P
$str
©©Q [
,
©©[ \
$str
©©] g
)
©©g h
;
©©h i
ViewBag
™™ 
.
™™ 
Ubigeo
™™ 
=
™™ 
usuario
™™ $
.
™™$ %
Ubigeo
™™% +
.
™™+ ,
Distrito
™™, 4
;
™™4 5
return
´´ 
View
´´ 
(
´´ 
usuario
´´ 
)
´´  
;
´´  !
}
≠≠ 	
[
ØØ 	
PermisosRol
ØØ	 
(
ØØ 
entRol
ØØ 
.
ØØ 
Cliente
ØØ #
)
ØØ# $
]
ØØ$ %
[
∞∞ 	
	Authorize
∞∞	 
]
∞∞ 
[
±± 	
HttpPost
±±	 
]
±± 
public
≤≤ 
ActionResult
≤≤  
EditarDatosCliente
≤≤ .
(
≤≤. /

EntUsuario
≤≤/ 9
usu
≤≤: =
,
≤≤= >
FormCollection
≤≤? M
frm
≤≤N Q
)
≤≤Q R
{
≥≥ 	
usu
µµ 
.
µµ 
Ubigeo
µµ 
=
µµ 
new
µµ 
	EntUbigeo
µµ &
{
∂∂ 
IdUbigeo
∑∑ 
=
∑∑ 
frm
∑∑ 
[
∑∑ 
$str
∑∑ %
]
∑∑% &
}
∏∏ 
;
∏∏ 
try
ππ 
{
∫∫ 
Boolean
ªª 
edita
ªª 
=
ªª 
Usuarioservice
ªª  .
.
ªª. /%
ActualizarAdministrador
ªª/ F
(
ªªF G
usu
ªªG J
)
ªªJ K
;
ªªK L
if
ºº 
(
ºº 
edita
ºº 
)
ºº 
{
ΩΩ 
CerrarSesion
ææ  
(
ææ  !
)
ææ! "
;
ææ" #
return
øø 
RedirectToAction
øø +
(
øø+ ,
$str
øø, 3
)
øø3 4
;
øø4 5
}
¿¿ 
else
¡¡ 
{
¬¬ 
return
√√ 
View
√√ 
(
√√  
usu
√√  #
)
√√# $
;
√√$ %
}
ƒƒ 
}
≈≈ 
catch
∆∆ 
(
∆∆ "
ApplicationException
∆∆ '
ex
∆∆( *
)
∆∆* +
{
«« 
return
»» 
RedirectToAction
»» '
(
»»' (
$str
»»( 1
,
»»1 2
new
»»3 6
{
»»7 8
mesjExceptio
»»9 E
=
»»F G
ex
»»H J
.
»»J K
Message
»»K R
}
»»S T
)
»»T U
;
»»U V
}
…… 
}
   	
[
ÃÃ 	
PermisosRol
ÃÃ	 
(
ÃÃ 
entRol
ÃÃ 
.
ÃÃ 
Cliente
ÃÃ #
)
ÃÃ# $
]
ÃÃ$ %
[
ÕÕ 	
HttpGet
ÕÕ	 
]
ÕÕ 
public
ŒŒ 
ActionResult
ŒŒ &
AgregarTempPrductCliente
ŒŒ 4
(
ŒŒ4 5
int
ŒŒ5 8
idprod
ŒŒ9 ?
)
ŒŒ? @
{
œœ 	

EntUsuario
–– 
usuario
–– 
=
––  
Session
––! (
[
––( )
$str
––) 2
]
––2 3
as
––4 6

EntUsuario
––7 A
;
––A B
var
—— 
prod
—— 
=
—— 
Productoservice
—— &
.
——& '
BuscarProductoId
——' 7
(
——7 8
idprod
——8 >
)
——> ?
;
——? @"
EntTemporaryProducts
““  
temporaryProducts
““! 2
=
““3 4
new
““5 8"
EntTemporaryProducts
““9 M
{
”” 
ProveedorProducto
‘‘ !
=
‘‘" #
new
‘‘$ '"
EntProveedorProducto
‘‘( <
{
’’ 
Producto
÷÷ 
=
÷÷ 
prod
÷÷ #
,
÷÷# $
}
◊◊ 
,
◊◊ 
Usuario
ÿÿ 
=
ÿÿ 
usuario
ÿÿ !
,
ÿÿ! "
Cantidad
ŸŸ 
=
ŸŸ 
$num
ŸŸ 
,
ŸŸ 
Subtotal
⁄⁄ 
=
⁄⁄ 
prod
⁄⁄ 
.
⁄⁄  
PrecioVenta
⁄⁄  +
}
€€ 
;
€€ 
try
‹‹ 
{
›› 
TemporaryPservice
ﬁﬁ !
.
ﬁﬁ! "(
CreaarTemporaryProductsCli
ﬁﬁ" <
(
ﬁﬁ< =
temporaryProducts
ﬁﬁ= N
)
ﬁﬁN O
;
ﬁﬁO P
return
ﬂﬂ 
RedirectToAction
ﬂﬂ '
(
ﬂﬂ' (
$str
ﬂﬂ( 1
)
ﬂﬂ1 2
;
ﬂﬂ2 3
}
‡‡ 
catch
·· 
(
·· 
	Exception
·· 
ex
·· 
)
··  
{
‚‚ 
return
„„ 
RedirectToAction
„„ '
(
„„' (
$str
„„( /
,
„„/ 0
$str
„„1 7
,
„„7 8
new
„„9 <
{
„„= >
mesjExeption
„„? K
=
„„L M
ex
„„N P
.
„„P Q
Message
„„Q X
}
„„Y Z
)
„„Z [
;
„„[ \
}
‰‰ 
}
ÂÂ 	
[
ËË 	
PermisosRol
ËË	 
(
ËË 
entRol
ËË 
.
ËË 
Administrador
ËË )
)
ËË) *
]
ËË* +
[
ÈÈ 	
	Authorize
ÈÈ	 
]
ÈÈ 
public
ÍÍ 
ActionResult
ÍÍ 
Admin
ÍÍ !
(
ÍÍ! "
)
ÍÍ" #
{
ÎÎ 	

EntUsuario
ÏÏ 
usuario
ÏÏ 
=
ÏÏ  
new
ÏÏ! $

EntUsuario
ÏÏ% /
(
ÏÏ/ 0
)
ÏÏ0 1
;
ÏÏ1 2
usuario
ÌÌ 
=
ÌÌ 
Session
ÌÌ 
[
ÌÌ 
$str
ÌÌ %
]
ÌÌ% &
as
ÌÌ' )

EntUsuario
ÌÌ* 4
;
ÌÌ4 5
ViewBag
ÓÓ 
.
ÓÓ 
correo
ÓÓ 
=
ÓÓ 
usuario
ÓÓ #
.
ÓÓ# $
Correo
ÓÓ$ *
;
ÓÓ* +
return
ÔÔ 
View
ÔÔ 
(
ÔÔ 
)
ÔÔ 
;
ÔÔ 
}
 	
[
ÚÚ 	
PermisosRol
ÚÚ	 
(
ÚÚ 
entRol
ÚÚ 
.
ÚÚ 
Administrador
ÚÚ )
)
ÚÚ) *
]
ÚÚ* +
[
ÛÛ 	
	Authorize
ÛÛ	 
]
ÛÛ 
[
ÙÙ 	
HttpGet
ÙÙ	 
]
ÙÙ 
public
ıı 
ActionResult
ıı &
EditarDatosAdministrador
ıı 4
(
ıı4 5
)
ıı5 6
{
ˆˆ 	
var
˜˜ 
usuario
˜˜ 
=
˜˜ 
Session
˜˜ !
[
˜˜! "
$str
˜˜" +
]
˜˜+ ,
as
˜˜- /

EntUsuario
˜˜0 :
;
˜˜: ;
ViewBag
¯¯ 
.
¯¯ 
listaUbigeo
¯¯ 
=
¯¯  !
new
¯¯" %

SelectList
¯¯& 0
(
¯¯0 1
Ubigeoservice
¯¯1 >
.
¯¯> ?
ListarDistrito
¯¯? M
(
¯¯M N
)
¯¯N O
,
¯¯O P
$str
¯¯Q [
,
¯¯[ \
$str
¯¯] g
)
¯¯g h
;
¯¯h i
ViewBag
˘˘ 
.
˘˘ 
Ubigeo
˘˘ 
=
˘˘ 
usuario
˘˘ $
.
˘˘$ %
Ubigeo
˘˘% +
.
˘˘+ ,
Distrito
˘˘, 4
;
˘˘4 5
return
˙˙ 
View
˙˙ 
(
˙˙ 
usuario
˙˙ 
)
˙˙  
;
˙˙  !
}
¸¸ 	
[
˝˝ 	
HttpPost
˝˝	 
]
˝˝ 
[
ˇˇ 	
PermisosRol
ˇˇ	 
(
ˇˇ 
entRol
ˇˇ 
.
ˇˇ 
Administrador
ˇˇ )
)
ˇˇ) *
]
ˇˇ* +
[
ÄÄ 	
	Authorize
ÄÄ	 
]
ÄÄ 
public
ÅÅ 
ActionResult
ÅÅ &
EditarDatosAdministrador
ÅÅ 4
(
ÅÅ4 5

EntUsuario
ÅÅ5 ?
usu
ÅÅ@ C
,
ÅÅC D
FormCollection
ÅÅE S
frm
ÅÅT W
)
ÅÅW X
{
ÇÇ 	
usu
ÑÑ 
.
ÑÑ 
Ubigeo
ÑÑ 
=
ÑÑ 
new
ÑÑ 
	EntUbigeo
ÑÑ &
{
ÖÖ 
IdUbigeo
ÜÜ 
=
ÜÜ 
frm
ÜÜ 
[
ÜÜ 
$str
ÜÜ %
]
ÜÜ% &
}
áá 
;
áá 
try
àà 
{
ââ 
Boolean
ää 
edita
ää 
=
ää 
Usuarioservice
ää  .
.
ää. /%
ActualizarAdministrador
ää/ F
(
ääF G
usu
ääG J
)
ääJ K
;
ääK L
if
ãã 
(
ãã 
edita
ãã 
)
ãã 
{
åå 
CerrarSesion
çç  
(
çç  !
)
çç! "
;
çç" #
return
éé 
RedirectToAction
éé +
(
éé+ ,
$str
éé, 3
)
éé3 4
;
éé4 5
}
èè 
else
êê 
{
ëë 
return
íí 
View
íí 
(
íí  
usu
íí  #
)
íí# $
;
íí$ %
}
ìì 
}
îî 
catch
ïï 
(
ïï "
ApplicationException
ïï '
ex
ïï( *
)
ïï* +
{
ññ 
return
óó 
RedirectToAction
óó '
(
óó' (
$str
óó( /
,
óó/ 0
new
óó1 4
{
óó5 6
mesjExceptio
óó7 C
=
óóD E
ex
óóF H
.
óóH I
Message
óóI P
}
óóQ R
)
óóR S
;
óóS T
}
òò 
}
ôô 	
}
ûû 
}°° ÿq
lC:\Users\mike\Desktop\Calidad_ofline\PRUEBAS-MADERERA\SISTEMA\CapaVistaWeb\Controllers\ProductoController.cs
	namespace		 	
MadereraCarocho		
 
.		 
Controllers		 %
{

 
[ 
	Authorize 
] 
public 

class 
ProductoController #
:$ %

Controller& 0
{ 
LogProducto 
Productoservice #
;# $ 
LogProveedorProducto $
ProveedorProductoservice 5
;5 6 
LogTemporaryProducts 
TemporaryPservice .
;. /
LogTipoProducto 
TipoProductoservice +
;+ ,
public 
ProductoController !
(! "
)" #
{ 	
Productoservice 
= 
new !
LogProducto" -
(- .
new. 1
DatProducto2 =
(= >
)> ?
)? @
;@ A
TemporaryPservice 
= 
new  # 
LogTemporaryProducts$ 8
(8 9
new9 < 
DatTemporaryProducts= Q
(Q R
)R S
)S T
;T U$
ProveedorProductoservice $
=% &
new' * 
LogProveedorProducto+ ?
(? @
new@ C 
DatProveedorProductoD X
(X Y
)Y Z
)Z [
;[ \
TipoProductoservice 
=  !
new" %
LogTipoProducto& 5
(5 6
new6 9
DatTipoProducto: I
(I J
)J K
)K L
;L M
} 	
[ 	
PermisosRol	 
( 
entRol 
. 
Administrador )
)) *
]* +
public 
ActionResult 
ListarParaComprar -
(- .
string. 4
dato5 9
)9 :
{ 	
List 
<  
EntProveedorProducto %
>% &
lista' ,
;, -
if   
(   
!   
String   
.   
IsNullOrEmpty   %
(  % &
dato  & *
)  * +
)  + ,
{!! 
lista"" 
="" $
ProveedorProductoservice"" 0
.""0 1%
BuscarProductoParaComprar""1 J
(""J K
dato""K O
)""O P
;""P Q
}## 
else$$ 
{%% 
lista&& 
=&& $
ProveedorProductoservice&& 0
.&&0 1%
ListarProductoParaComprar&&1 J
(&&J K
)&&K L
;&&L M
}'' 
return** 
View** 
(** 
lista** 
)** 
;** 
}++ 	
[-- 	
PermisosRol--	 
(-- 
entRol-- 
.-- 
Administrador-- )
)--) *
]--* +
public.. 
ActionResult.. 
ListarProducto.. *
(..* +
string.., 2
dato..3 7
)..7 8
{// 	
List00 
<00 
EntProducto00 
>00 
lista00 #
;00# $
if11 
(11 
!11 
string11 
.11 
IsNullOrEmpty11 $
(11$ %
dato11% )
)11) *
)11* +
lista22 
=22 
Productoservice22 &
.22& '
BuscarProducto22' 5
(225 6
dato226 :
)22: ;
;22; <
else33 
lista44 
=44 
Productoservice44 %
.44% &
ListarProducto44& 4
(444 5
)445 6
;446 7
ViewBag66 
.66 
	listaTipo66 
=66 
new66  #

SelectList66$ .
(66. /
TipoProductoservice66/ B
.66B C%
SelectListTipoProductodat66C \
(66\ ]
$num66] ^
)66^ _
,66_ `
$str66a r
,66r s
$str66t |
)66| }
;66} ~
return77 
View77 
(77 
lista77 
)77 
;77 
}88 	
[:: 	
PermisosRol::	 
(:: 
entRol:: 
.:: 
Administrador:: )
)::) *
]::* +
[;; 	
HttpPost;;	 
];; 
public<< 
ActionResult<< 
CrearProducto<< )
(<<) *
string<<* 0
cNombreP<<1 9
,<<9 :
string<<; A

cLongitudP<<B L
,<<L M
string<<N T
	cdiametro<<U ^
,<<^ _
string<<` f
cPrecioVenta<<g s
,<<s t
string<<u {
cprecioCompra	<<| â
,
<<â ä
FormCollection
<<ã ô
frmTipo
<<ö °
)
<<° ¢
{== 	
try?? 
{@@ 
EntProductoAA 
pAA 
=AA 
newAA  #
EntProductoAA$ /
{BB 
NombreCC 
=CC 
cNombrePCC %
,CC% &
LongitudDD 
=DD 
DoubleDD %
.DD% &
ParseDD& +
(DD+ ,

cLongitudPDD, 6
)DD6 7
,DD7 8
DiametroEE 
=EE 
DoubleEE %
.EE% &
ParseEE& +
(EE+ ,
	cdiametroEE, 5
)EE5 6
,EE6 7
PrecioVentaFF 
=FF  !
DoubleFF" (
.FF( )
ParseFF) .
(FF. /
cPrecioVentaFF/ ;
)FF; <
,FF< =
TipoGG 
=GG 
newGG 
EntTipoProductoGG .
{HH 
IdTipo_productoII '
=II( )
ConvertII* 1
.II1 2
ToInt32II2 9
(II9 :
frmTipoII: A
[IIA B
$strIIB I
]III J
)IIJ K
}JJ 
,JJ 
}KK 
;KK 
ProductoserviceLL 
.LL  
CrearProductoLL  -
(LL- .
pLL. /
)LL/ 0
;LL0 1
}NN 
catchOO 
(OO 
	ExceptionOO 
exOO 
)OO  
{PP 
returnQQ 
RedirectToActionQQ '
(QQ' (
$strQQ( 8
,QQ8 9
newQQ: =
{QQ> ?
mesjExeptionQQ@ L
=QQM N
exQQO Q
.QQQ R
MessageQQR Y
}QQZ [
)QQ[ \
;QQ\ ]
}RR 
returnSS 
RedirectToActionSS #
(SS# $
$strSS$ 4
)SS4 5
;SS5 6
}TT 	
[WW 	
PermisosRolWW	 
(WW 
entRolWW 
.WW 
AdministradorWW )
)WW) *
]WW* +
[XX 	
HttpGetXX	 
]XX 
publicYY 
ActionResultYY 
EditarProductoYY *
(YY* +
intYY+ .
idprodYY/ 5
)YY5 6
{ZZ 	
var[[ 
prod[[ 
=[[ 
Productoservice[[ &
.[[& '
BuscarProductoId[[' 7
([[7 8
idprod[[8 >
)[[> ?
;[[? @
ViewBag\\ 
.\\ 

listaTipos\\ 
=\\  
new\\! $

SelectList\\% /
(\\/ 0
TipoProductoservice\\0 C
.\\C D%
SelectListTipoProductodat\\D ]
(\\] ^
prod\\^ b
.\\b c

IdProducto\\c m
)\\m n
,\\n o
$str	\\p Å
,
\\Å Ç
$str
\\É ã
)
\\ã å
;
\\å ç
return]] 
View]] 
(]] 
prod]] 
)]] 
;]] 
}^^ 	
[`` 	
PermisosRol``	 
(`` 
entRol`` 
.`` 
Administrador`` )
)``) *
]``* +
[aa 	
HttpPostaa	 
]aa 
publicbb 
ActionResultbb 
EditarProductobb *
(bb* +
EntProductobb+ 6
pbb7 8
,bb8 9
FormCollectionbb: H
frmbbI L
)bbL M
{cc 	
pee 
.ee 

IdProductoee 
=ee 
pee 
.ee 

IdProductoee '
;ee' (
pff 
.ff 
Nombreff 
=ff 
pff 
.ff 
Nombreff 
;ff  
pgg 
.gg 
Longitudgg 
=gg 
pgg 
.gg 
Longitudgg #
;gg# $
phh 
.hh 
Diametrohh 
=hh 
phh 
.hh 
Diametrohh #
;hh# $
pii 
.ii 
Activoii 
=ii 
pii 
.ii 
Activoii 
;ii  
pjj 
.jj 
Tipojj 
=jj 
newjj 
EntTipoProductojj (
{kk 
IdTipo_productoll 
=ll  !
Convertll" )
.ll) *
ToInt32ll* 1
(ll1 2
frmll2 5
[ll5 6
$strll6 <
]ll< =
)ll= >
}mm 
;mm 
tryoo 
{pp 
Booleanrr 
editarr 
=rr 
Productoservicerr  /
.rr/ 0
ActualizarProductorr0 B
(rrB C
prrC D
)rrD E
;rrE F
ifss 
(ss 
editass 
)ss 
{tt 
returnuu 
RedirectToActionuu +
(uu+ ,
$struu, <
)uu< =
;uu= >
}vv 
elseww 
{xx 
returnyy 
Viewyy 
(yy  
pyy  !
)yy! "
;yy" #
}zz 
}{{ 
catch|| 
(||  
ApplicationException|| '
ex||( *
)||* +
{}} 
return~~ 
RedirectToAction~~ '
(~~' (
$str~~( 8
,~~8 9
new~~: =
{~~> ?
mesjExceptio~~@ L
=~~M N
ex~~O Q
.~~Q R
Message~~R Y
}~~Z [
)~~[ \
;~~\ ]
} 
}
ÄÄ 	
[
ÉÉ 	
HttpGet
ÉÉ	 
]
ÉÉ 
public
ÑÑ 
ActionResult
ÑÑ 
EliminarProducto
ÑÑ ,
(
ÑÑ, -
int
ÑÑ- 0
idP
ÑÑ1 4
)
ÑÑ4 5
{
ÖÖ 	
try
ÜÜ 
{
áá 
bool
àà 
elimina
àà 
=
àà 
Productoservice
àà .
.
àà. /
EliminarProducto
àà/ ?
(
àà? @
idP
àà@ C
)
ààC D
;
ààD E
}
ââ 
catch
ää 
(
ää 
	Exception
ää 
ex
ää 
)
ää  
{
ãã 
return
çç 
RedirectToAction
çç '
(
çç' (
$str
çç( 8
,
çç8 9
new
çç: =
{
çç> ?
mesjExeption
çç@ L
=
ççM N
ex
ççO Q
.
ççQ R
Message
ççR Y
}
ççZ [
)
çç[ \
;
çç\ ]
}
éé 
return
èè 
RedirectToAction
èè #
(
èè# $
$str
èè$ 4
)
èè4 5
;
èè5 6
}
êê 	
[
íí 	
HttpGet
íí	 
]
íí 
public
ìì 
ActionResult
ìì 
EliminarDetalle
ìì +
(
ìì+ ,
int
ìì, /
idprov
ìì0 6
,
ìì6 7
int
ìì8 ;
idprod
ìì< B
)
ììB C
{
îî 	
try
ïï 
{
ññ 
bool
óó 
elimina
óó 
=
óó &
ProveedorProductoservice
óó 7
.
óó7 8&
EliminarDetalleProveedor
óó8 P
(
óóP Q
idprov
óóQ W
,
óóW X
idprod
óóY _
)
óó_ `
;
óó` a
}
òò 
catch
ôô 
(
ôô 
	Exception
ôô 
ex
ôô 
)
ôô  
{
öö 
return
õõ 
RedirectToAction
õõ '
(
õõ' (
$str
õõ( ;
,
õõ; <
new
õõ= @
{
õõA B
mesjExeption
õõC O
=
õõP Q
ex
õõR T
.
õõT U
Message
õõU \
}
õõ] ^
)
õõ^ _
;
õõ_ `
}
úú 
return
ûû 
RedirectToAction
ûû #
(
ûû# $
$str
ûû$ 7
)
ûû7 8
;
ûû8 9
}
üü 	
[
°° 	
HttpGet
°°	 
]
°° 
public
¢¢ 
ActionResult
¢¢ 
AgregarTempPrduct
¢¢ -
(
¢¢- .
int
¢¢. 1
idprod
¢¢2 8
,
¢¢8 9
int
¢¢: =
idprov
¢¢> D
)
¢¢D E
{
££ 	

EntUsuario
§§ 
usuario
§§ 
=
§§  
Session
§§! (
[
§§( )
$str
§§) 2
]
§§2 3
as
§§4 6

EntUsuario
§§7 A
;
§§A B
var
•• 
proprod
•• 
=
•• &
ProveedorProductoservice
•• 2
.
••2 3&
BuscarProvedorProductoId
••3 K
(
••K L
idprod
••L R
,
••R S
idprov
••T Z
)
••Z [
;
••[ \"
EntTemporaryProducts
¶¶  
temporaryProducts
¶¶! 2
=
¶¶3 4
new
¶¶5 8"
EntTemporaryProducts
¶¶9 M
{
ßß 
ProveedorProducto
®® !
=
®®" #
proprod
®®$ +
,
®®+ ,
Usuario
©© 
=
©© 
usuario
©© !
,
©©! "
Cantidad
™™ 
=
™™ 
$num
™™ 
,
™™ 
Subtotal
´´ 
=
´´ 
proprod
´´ "
.
´´" #
PrecioCompra
´´# /
}
¨¨ 
;
¨¨ 
try
≠≠ 
{
ÆÆ 
TemporaryPservice
ØØ !
.
ØØ! "%
CreaarTemporaryProducts
ØØ" 9
(
ØØ9 :
temporaryProducts
ØØ: K
)
ØØK L
;
ØØL M
return
∞∞ 
RedirectToAction
∞∞ '
(
∞∞' (
$str
∞∞( ;
)
∞∞; <
;
∞∞< =
}
±± 
catch
≤≤ 
(
≤≤ 
	Exception
≤≤ 
ex
≤≤ 
)
≤≤  
{
≥≥ 
return
¥¥ 
RedirectToAction
¥¥ '
(
¥¥' (
$str
¥¥( /
,
¥¥/ 0
$str
¥¥1 7
,
¥¥7 8
new
¥¥9 <
{
¥¥= >
mesjExeption
¥¥? K
=
¥¥L M
ex
¥¥N P
.
¥¥P Q
Message
¥¥Q X
}
¥¥Y Z
)
¥¥Z [
;
¥¥[ \
}
µµ 
}
¡¡ 	
}
√√ 
}ƒƒ Ã
mC:\Users\mike\Desktop\Calidad_ofline\PRUEBAS-MADERERA\SISTEMA\CapaVistaWeb\Controllers\ProveedorController.cs
	namespace

 	
MadereraCarocho


 
.

 
Controllers

 %
{ 
[ 
PermisosRol 
( 
entRol 
. 
Administrador %
)% &
]& '
[ 
	Authorize 
] 
public 

class 
ProveedorController $
:% &

Controller' 1
{ 
LogProducto 
Productoservice #
;# $ 
LogProveedorProducto $
ProveedorProductoservice 5
;5 6
	LogUbigeo 
Ubigeoservice 
;  
LogProveedor 
Proveedorservice %
;% &
ValidatorHelper 
validatorHelper '
=( )
new* -
ValidatorHelper. =
(= >
)> ?
;? @
public 
ProveedorController "
(" #
)# $
{ 	
Productoservice 
= 
new !
LogProducto" -
(- .
new. 1
DatProducto2 =
(= >
)> ?
)? @
;@ A$
ProveedorProductoservice $
=% &
new' * 
LogProveedorProducto+ ?
(? @
new@ C 
DatProveedorProductoD X
(X Y
)Y Z
)Z [
;[ \
Ubigeoservice 
= 
new 
	LogUbigeo  )
() *
new* -
	DatUbigeo. 7
(7 8
)8 9
)9 :
;: ;
Proveedorservice 
= 
new "
LogProveedor# /
(/ 0
new0 3
DatProveedor4 @
(@ A
)A B
)B C
;C D
} 	
public 
ActionResult 
Listar "
(" #
string# )
dato* .
). /
{ 	
List 
< 
EntProveedor 
> 
lista $
;$ %
if   
(   
!   
string   
.   
IsNullOrEmpty   %
(  % &
dato  & *
)  * +
)  + ,
{!! 
lista"" 
="" 
Proveedorservice"" (
.""( )
BuscarProveedor"") 8
(""8 9
dato""9 =
)""= >
;""> ?
}## 
else$$ 
{%% 
lista&& 
=&& 
Proveedorservice&& (
.&&( )
ListarProveedor&&) 8
(&&8 9
)&&9 :
;&&: ;
}(( 
List)) 
<)) 
	EntUbigeo)) 
>)) 
listaUbigeo)) '
=))( )
Ubigeoservice))* 7
.))7 8
ListarDistrito))8 F
())F G
)))G H
;))H I
var** 
lsUbigeo** 
=** 
new** 

SelectList** )
(**) *
listaUbigeo*** 5
,**5 6
$str**7 A
,**A B
$str**C M
)**M N
;**N O
ViewBag++ 
.++ 
listaUbigeo++ 
=++  !
lsUbigeo++" *
;++* +
return,, 
View,, 
(,, 
lista,, 
),, 
;,, 
}-- 	
[.. 	
HttpGet..	 
].. 
public// 
ActionResult// 
RegistrarProveedor// .
(//. /
)/// 0
{00 	
List11 
<11 
	EntUbigeo11 
>11 
listaUbigeo11 '
=11( )
Ubigeoservice11* 7
.117 8
ListarDistrito118 F
(11F G
)11G H
;11H I
var22 
lsUbigeo22 
=22 
new22 

SelectList22 )
(22) *
listaUbigeo22* 5
,225 6
$str227 A
,22A B
$str22C M
)22M N
;22N O
ViewBag33 
.33 
listaUbigeo33 
=33  !
lsUbigeo33" *
;33* +
return44 
View44 
(44 
)44 
;44 
}55 	
[77 	
HttpPost77	 
]77 
public88 
ActionResult88 
RegistrarProveedor88 .
(88. /
string88/ 5
nombre886 <
,88= >
string88? E
ruc88F I
,88I J
string88K Q
email88R W
,88W X
string88Y _
telefono88` h
,88h i
string88j p
description88q |
,88| }
FormCollection	88~ å
frm
88ç ê
)
88ê ë
{99 	
bool:: 

isNonEmpty:: 
=:: 
!:: 
string:: #
.::# $
IsNullOrEmpty::$ 1
(::1 2
nombre::2 8
)::8 9
||::: <
!::= >
string::> D
.::D E
IsNullOrEmpty::E R
(::R S
ruc::S V
)::V W
||::X Z
!::[ \
string::\ b
.::b c
IsNullOrEmpty::c p
(::p q
email::q v
)::v w
||::x z
!::{ |
string	::| Ç
.
::Ç É
IsNullOrEmpty
::É ê
(
::ê ë
telefono
::ë ô
)
::ô ö
||
::õ ù
!
::û ü
string
::ü •
.
::• ¶
IsNullOrEmpty
::¶ ≥
(
::≥ ¥
description
::¥ ø
)
::ø ¿
;
::¿ ¡
try;; 
{<< 
if== 
(== 

isNonEmpty== 
)== 
{>> 
EntProveedor??  
p??! "
=??# $
new??% (
EntProveedor??) 5
{@@ 
RazonSocialAA #
=AA$ %
nombreAA& ,
,AA, -
RucBB 
=BB 
rucBB !
,BB! "
CorreoCC 
=CC  
emailCC! &
,CC& '
TelefonoDD  
=DD! "
telefonoDD# +
,DD+ ,
DescripcionEE #
=EE$ %
descriptionEE& 1
,EE1 2
EstProveedorFF $
=FF% &
trueFF' +
,FF+ ,
UbigeoGG 
=GG  
newGG! $
	EntUbigeoGG% .
{HH 
IdUbigeoII $
=II% &
frmII' *
[II* +
$strII+ 3
]II3 4
.II4 5
ToStringII5 =
(II= >
)II> ?
}JJ 
}KK 
;KK 
boolMM 
insertaMM  
=MM! "
ProveedorserviceMM# 3
.MM3 4
CrearProveedorMM4 B
(MMB C
pMMC D
)MMD E
;MME F
}NN 
}PP 
catchQQ 
(QQ 
	ExceptionQQ 
exQQ 
)QQ  
{RR 
TempDataSS 
[SS 
$strSS  
]SS  !
=SS" #
exSS$ &
.SS& '
MessageSS' .
;SS. /
returnTT 
RedirectToActionTT '
(TT' (
$strTT( 7
)TT7 8
;TT8 9
}UU 
returnVV 
RedirectToActionVV #
(VV# $
$strVV$ ,
)VV, -
;VV- .
}WW 	
[ZZ 	
HttpGetZZ	 
]ZZ 
public[[ 
ActionResult[[ 
EditarProveedor[[ +
([[+ ,
int[[, /
idprov[[0 6
)[[6 7
{\\ 	
EntProveedor]] 
prov]] 
=]] 
Proveedorservice]]  0
.]]0 1
BuscarIdProveedor]]1 B
(]]B C
idprov]]C I
)]]I J
;]]J K
List__ 
<__ 
	EntUbigeo__ 
>__ 
listaUbigeo__ '
=__( )
Ubigeoservice__* 7
.__7 8
ListarDistrito__8 F
(__F G
)__G H
;__H I
var`` 
lsUbigeo`` 
=`` 
new`` 

SelectList`` )
(``) *
listaUbigeo``* 5
,``5 6
$str``7 A
,``A B
$str``C M
)``M N
;``N O
ViewBagaa 
.aa 
listaUbigeoaa 
=aa  !
lsUbigeoaa" *
;aa* +
returncc 
Viewcc 
(cc 
provcc 
)cc 
;cc 
}dd 	
[ff 	
HttpPostff	 
]ff 
publicgg 
ActionResultgg 
EditarProveedorgg +
(gg+ ,
EntProveedorgg, 8
pgg9 :
,gg: ;
FormCollectiongg< J
frmggK N
)ggN O
{hh 	
boolii 

isNonEmptyii 
=ii 
!ii 
stringii %
.ii% &
IsNullOrEmptyii& 3
(ii3 4
pii4 5
.ii5 6
RazonSocialii6 A
)iiA B
||iiC E
!iiF G
stringiiG M
.iiM N
IsNullOrEmptyiiN [
(ii[ \
pii\ ]
.ii] ^
Rucii^ a
)iia b
||iic e
!iif g
stringiig m
.iim n
IsNullOrEmptyiin {
(ii{ |
pii| }
.ii} ~
Correo	ii~ Ñ
)
iiÑ Ö
||
iiÜ à
!
iiâ ä
string
iiä ê
.
iiê ë
IsNullOrEmpty
iië û
(
iiû ü
p
iiü †
.
ii† °
Telefono
ii° ©
)
ii© ™
||
ii´ ≠
!
iiÆ Ø
string
iiØ µ
.
iiµ ∂
IsNullOrEmpty
ii∂ √
(
ii√ ƒ
p
iiƒ ≈
.
ii≈ ∆
Descripcion
ii∆ —
)
ii— “
;
ii“ ”
trykk 
{ll 
ifmm 
(mm 

isNonEmptymm 
)mm 
{nn 
poo 
.oo 
Ubigeooo 
=oo 
newoo "
	EntUbigeooo# ,
{pp 
IdUbigeoqq  
=qq! "
frmqq# &
[qq& '
$strqq' ,
]qq, -
}rr 
;rr 
Proveedorservicess %
.ss% &
ActualizarProveedorss& 9
(ss9 :
pss: ;
)ss; <
;ss< =
}tt 
elsett 
{uu 
TempDatavv 
[vv 
$strvv (
]vv( )
=vv* +
$strvv, N
;vvN O
returnxx 
Viewxx 
(xx  
pxx  !
)xx! "
;xx" #
}yy 
}{{ 
catch|| 
(|| 
	Exception|| 
ex|| 
)||  
{}} 
TempData~~ 
[~~ 
$str~~ 
]~~  
=~~! "
ex~~# %
.~~% &
Message~~& -
;~~- .
return 
View 
( 
p 
) 
; 
}
ÄÄ 
return
ÅÅ 
RedirectToAction
ÅÅ #
(
ÅÅ# $
$str
ÅÅ$ ,
)
ÅÅ, -
;
ÅÅ- .
}
ÇÇ 	
[
ÑÑ 	
HttpGet
ÑÑ	 
]
ÑÑ 
public
ÖÖ 
ActionResult
ÖÖ 
EliminarProveedor
ÖÖ -
(
ÖÖ- .
int
ÖÖ. 1
idc
ÖÖ2 5
)
ÖÖ5 6
{
ÜÜ 	
try
áá 
{
àà 
bool
ââ 
elimina
ââ 
=
ââ 
Proveedorservice
ââ /
.
ââ/ 0
EliminarProveedor
ââ0 A
(
ââA B
idc
ââB E
)
ââE F
;
ââF G
if
ää 
(
ää 
elimina
ää 
)
ää 
{
ãã 
return
åå 
RedirectToAction
åå +
(
åå+ ,
$str
åå, 4
)
åå4 5
;
åå5 6
}
çç 
}
éé 
catch
èè 
(
èè 
	Exception
èè 
ex
èè 
)
èè  
{
êê 
return
ëë 
RedirectToAction
ëë '
(
ëë' (
$str
ëë( 0
,
ëë0 1
new
ëë2 5
{
ëë6 7
mesjExeption
ëë8 D
=
ëëE F
ex
ëëG I
.
ëëI J
Message
ëëJ Q
}
ëëR S
)
ëëS T
;
ëëT U
}
íí 
return
ìì 
RedirectToAction
ìì #
(
ìì# $
$str
ìì$ ,
)
ìì, -
;
ìì- .
}
îî 	
[
ññ 	
HttpGet
ññ	 
]
ññ 
public
óó 
ActionResult
óó 
MostrarDetalle
óó *
(
óó* +
int
óó+ .
idp
óó/ 2
)
óó2 3
{
òò 	
try
ôô 
{
öö 
ViewBag
õõ 
.
õõ 
producto
õõ  
=
õõ! "
new
õõ# &

SelectList
õõ' 1
(
õõ1 2
Productoservice
õõ2 A
.
õõA B
ListarProducto
õõB P
(
õõP Q
)
õõQ R
,
õõR S
$str
õõS _
,
õõ_ `
$str
õõa q
)
õõq r
;
õõr s
return
úú 
View
úú 
(
úú 
_
úú 
=
úú &
ProveedorProductoservice
úú  8
.
úú8 9&
MostrarDetalleProvedorId
úú9 Q
(
úúQ R
idp
úúR U
)
úúU V
)
úúV W
;
úúW X
}
ùù 
catch
ûû 
(
ûû 
	Exception
ûû 
ex
ûû 
)
ûû  
{
üü 
return
†† 
RedirectToAction
†† '
(
††' (
$str
††( 0
,
††0 1
new
††2 5
{
††6 7
mesjExeption
††8 D
=
††E F
ex
††G I
.
††I J
Message
††J Q
}
††R S
)
††S T
;
††T U
}
°° 
}
¢¢ 	
[
•• 	
HttpPost
••	 
]
•• 
public
¶¶ 
ActionResult
¶¶ 
ElegirProductos
¶¶ +
(
¶¶+ ,
int
¶¶, /
	proveedor
¶¶0 9
,
¶¶9 :
double
¶¶; A
precio
¶¶B H
,
¶¶H I
FormCollection
¶¶J X
frm
¶¶Y \
)
¶¶\ ]
{
ßß 	"
EntProveedorProducto
®®  
PP
®®! #
=
®®$ %
new
®®& )"
EntProveedorProducto
®®* >
{
©© 
	Proveedor
™™ 
=
™™ 
new
™™ 
EntProveedor
™™  ,
{
´´ 
IdProveedor
¨¨ 
=
¨¨  !
	proveedor
¨¨" +
,
¨¨+ ,
}
≠≠ 
,
≠≠ 
Producto
ÆÆ 
=
ÆÆ 
new
ÆÆ 
EntProducto
ÆÆ *
{
ØØ 

IdProducto
∞∞ 
=
∞∞  
Convert
∞∞! (
.
∞∞( )
ToInt32
∞∞) 0
(
∞∞0 1
frm
∞∞1 4
[
∞∞4 5
$str
∞∞5 9
]
∞∞9 :
)
∞∞: ;
}
±± 
,
±± 
PrecioCompra
≤≤ 
=
≤≤ 
precio
≤≤ #
}
¥¥ 
;
¥¥ &
ProveedorProductoservice
µµ $
.
µµ$ %$
CrearProveedorProducto
µµ% ;
(
µµ; <
PP
µµ< >
)
µµ> ?
;
µµ? @
return
∂∂ 
RedirectToAction
∂∂ #
(
∂∂# $
$str
∂∂$ ,
)
∂∂, -
;
∂∂- .
}
∑∑ 	
[
ππ 	
HttpGet
ππ	 
]
ππ 
public
∫∫ 
ActionResult
∫∫ 
EliminarDetalle
∫∫ +
(
∫∫+ ,
int
∫∫, /
idprov
∫∫0 6
,
∫∫6 7
int
∫∫8 ;
idprod
∫∫< B
)
∫∫B C
{
ªª 	
try
ºº 
{
ΩΩ 
bool
ææ 
elimina
ææ 
=
ææ &
ProveedorProductoservice
ææ 7
.
ææ7 8&
EliminarDetalleProveedor
ææ8 P
(
ææP Q
idprov
ææQ W
,
ææW X
idprod
ææY _
)
ææ_ `
;
ææ` a
}
øø 
catch
¿¿ 
(
¿¿ 
	Exception
¿¿ 
ex
¿¿ 
)
¿¿  
{
¡¡ 
return
¬¬ 
RedirectToAction
¬¬ '
(
¬¬' (
$str
¬¬( 0
,
¬¬0 1
new
¬¬2 5
{
¬¬6 7
mesjExeption
¬¬8 D
=
¬¬E F
ex
¬¬G I
.
¬¬I J
Message
¬¬J Q
}
¬¬R S
)
¬¬S T
;
¬¬T U
}
√√ 
return
≈≈ 
RedirectToAction
≈≈ #
(
≈≈# $
$str
≈≈$ ,
)
≈≈, -
;
≈≈- .
}
∆∆ 	
}
«« 
}»» ˆ3
iC:\Users\mike\Desktop\Calidad_ofline\PRUEBAS-MADERERA\SISTEMA\CapaVistaWeb\Controllers\VentaController.cs
	namespace		 	
MadereraCarocho		
 
.		 
Controllers		 %
{

 
[ 
	Authorize 
] 
public 

class 
VentaController  
:! "

Controller# -
{ 
LogVenta 
Ventaservice 
; 
LogDetVenta 
DetVentaservice #
;# $ 
LogTemporaryProducts 
TemporaryPservice .
;. /
public 
VentaController 
( 
)  
{ 	
Ventaservice 
= 
new 
LogVenta '
(' (
new( +
DatVenta, 4
(4 5
)5 6
)6 7
;7 8
DetVentaservice 
= 
new !
LogDetVenta" -
(- .
new. 1
DatDetVenta2 =
(= >
)> ?
)? @
;@ A
TemporaryPservice 
= 
new  # 
LogTemporaryProducts$ 8
(8 9
new9 < 
DatTemporaryProducts= Q
(Q R
)R S
)S T
;T U
} 	
[ 	
PermisosRol	 
( 
entRol 
. 
Cliente #
)# $
]$ %
public 
ActionResult 
ListarVenta '
(' (
)( )
{ 	

EntUsuario 
usuario 
=  
new! $

EntUsuario% /
(/ 0
)0 1
;1 2
usuario 
= 
Session 
[ 
$str '
]' (
as) +

EntUsuario, 6
;6 7
return 
View 
( 
Ventaservice $
.$ %
ListarVenta% 0
(0 1
usuario1 8
.8 9
	IdUsuario9 B
)B C
)C D
;D E
}   	
["" 	
PermisosRol""	 
("" 
entRol"" 
."" 
Cliente"" #
)""# $
]""$ %
public## 
ActionResult## 
MostrarDetalle## *
(##* +
int##+ .
idv##/ 2
)##2 3
{$$ 	
return%% 
View%% 
(%% 
_%% 
=%% 
DetVentaservice%% +
.%%+ ,
Mostrardetventa%%, ;
(%%; <
idv%%< ?
)%%? @
)%%@ A
;%%A B
}&& 	
[)) 	
PermisosRol))	 
()) 
entRol)) 
.)) 
Cliente)) #
)))# $
]))$ %
public** 
ActionResult** 
ConfirmarVenta** *
(*** +
)**+ ,
{++ 	
try,, 
{-- 

EntUsuario.. 
usuario.. "
=..# $
new..% (

EntUsuario..) 3
(..3 4
)..4 5
;..5 6
usuario// 
=// 
Session// !
[//! "
$str//" +
]//+ ,
as//- /

EntUsuario//0 :
;//: ;
List00 
<00  
EntTemporaryProducts00 )
>00) *
list00+ /
=000 1
new002 5
List006 :
<00: ; 
EntTemporaryProducts00; O
>00O P
(00P Q
)00Q R
;00R S
list11 
=11 
TemporaryPservice11 (
.11( )'
MostrarTemporaryProductsCli11) D
(11D E
usuario11E L
.11L M
	IdUsuario11M V
)11V W
;11W X
double33 
total33 
=33 
$num33  
;33  !
for44 
(44 
int44 
i44 
=44 
$num44 
;44 
i44  !
<44" #
list44$ (
.44( )
Count44) .
(44. /
)44/ 0
;440 1
i442 3
++443 5
)445 6
{55 
total66 
+=66 
list66 !
[66! "
i66" #
]66# $
.66$ %
Subtotal66% -
;66- .
}77 
EntVenta99 
venta99 
=99  
new99! $
EntVenta99% -
{:: 
Cliente;; 
=;; 
usuario;; %
,;;% &
Total<< 
=<< 
total<< !
}== 
;== 
int?? 
idVenta?? 
=?? 
Ventaservice?? *
.??* +

CrearVenta??+ 5
(??5 6
venta??6 ;
)??; <
;??< =
venta@@ 
.@@ 
IdVenta@@ 
=@@ 
idVenta@@  '
;@@' (
EntDetVentaBB 
detBB 
=BB  !
newBB" %
EntDetVentaBB& 1
(BB1 2
)BB2 3
;BB3 4
forDD 
(DD 
intDD 
iDD 
=DD 
$numDD 
;DD 
iDD  !
<DD" #
listDD$ (
.DD( )
CountDD) .
;DD. /
iDD0 1
++DD1 3
)DD3 4
{EE 
detFF 
.FF 
VentaFF 
=FF 
ventaFF  %
;FF% &
detGG 
.GG 
ProductoGG  
=GG! "
newGG# &
EntProductoGG' 2
{HH 

IdProductoII "
=II# $
listII% )
[II) *
iII* +
]II+ ,
.II, -
ProveedorProductoII- >
.II> ?
ProductoII? G
.IIG H

IdProductoIIH R
}JJ 
;JJ 
detKK 
.KK 
CantidadKK  
=KK! "
listKK# '
[KK' (
iKK( )
]KK) *
.KK* +
CantidadKK+ 3
;KK3 4
detLL 
.LL 
SubTotalLL  
=LL! "
listLL# '
[LL' (
iLL( )
]LL) *
.LL* +
SubtotalLL+ 3
;LL3 4
DetVentaserviceNN #
.NN# $
CrearDetVentaNN$ 1
(NN1 2
detNN2 5
)NN5 6
;NN6 7
}OO 
returnPP 
RedirectToActionPP '
(PP' (
$strPP( 5
)PP5 6
;PP6 7
}RR 
catchSS 
{TT 
returnUU 
RedirectToActionUU '
(UU' (
$strUU( /
,UU/ 0
$strUU1 7
)UU7 8
;UU8 9
}WW 
}XX 	
}YY 
}ZZ á	
YC:\Users\mike\Desktop\Calidad_ofline\PRUEBAS-MADERERA\SISTEMA\CapaVistaWeb\Global.asax.cs
	namespace 	
MadereraCarocho
 
{ 
public 

class 
MvcApplication 
:  !
System" (
.( )
Web) ,
., -
HttpApplication- <
{ 
	protected		 
void		 
Application_Start		 (
(		( )
)		) *
{

 	
AreaRegistration 
. 
RegisterAllAreas -
(- .
). /
;/ 0
FilterConfig 
. !
RegisterGlobalFilters .
(. /
GlobalFilters/ <
.< =
Filters= D
)D E
;E F
RouteConfig 
. 
RegisterRoutes &
(& '

RouteTable' 1
.1 2
Routes2 8
)8 9
;9 :
BundleConfig 
. 
RegisterBundles (
(( )
BundleTable) 4
.4 5
Bundles5 <
)< =
;= >
} 	
} 
} È
kC:\Users\mike\Desktop\Calidad_ofline\PRUEBAS-MADERERA\SISTEMA\CapaVistaWeb\Permisos\PermisosRolAttribute.cs
	namespace 	
MadereraCarocho
 
. 
Permisos "
{ 
public		 

class		  
PermisosRolAttribute		 %
:		& '!
ActionFilterAttribute		( =
{

 
private 
readonly 
entRol 
Rol  #
;# $
public  
PermisosRolAttribute #
(# $
entRol$ *
Rol+ .
). /
{ 	
this 
. 
Rol 
= 
Rol 
; 
} 	
public 
override 
void 
OnActionExecuted -
(- .!
ActionExecutedContext. C
filterContextD Q
)Q R
{ 	
if 
( 
HttpContext 
. 
Current #
.# $
Session$ +
[+ ,
$str, 5
]5 6
!=7 9
null: >
)> ?
{ 
var 
usuario 
= 
HttpContext )
.) *
Current* 1
.1 2
Session2 9
[9 :
$str: C
]C D
asE G

EntUsuarioH R
;R S
if 
( 
usuario 
. 
Rol 
!=  "
Rol# &
)& '
{ 
filterContext !
.! "
Result" (
=) *
new+ .
RedirectResult/ =
(= >
$str> R
)R S
;S T
} 
} 
else 
{   
filterContext!! 
.!! 
Result!! $
=!!% &
new!!' *
RedirectResult!!+ 9
(!!9 :
$str!!: H
)!!H I
;!!I J
}"" 
base## 
.## 
OnActionExecuted## !
(##! "
filterContext##" /
)##/ 0
;##0 1
}$$ 	
}%% 
}&& ê
eC:\Users\mike\Desktop\Calidad_ofline\PRUEBAS-MADERERA\SISTEMA\CapaVistaWeb\Properties\AssemblyInfo.cs
[ 
assembly 	
:	 

AssemblyTitle 
( 
$str *
)* +
]+ ,
[ 
assembly 	
:	 

AssemblyDescription 
( 
$str !
)! "
]" #
[		 
assembly		 	
:			 
!
AssemblyConfiguration		  
(		  !
$str		! #
)		# $
]		$ %
[

 
assembly

 	
:

	 

AssemblyCompany

 
(

 
$str

 
)

 
]

 
[ 
assembly 	
:	 

AssemblyProduct 
( 
$str ,
), -
]- .
[ 
assembly 	
:	 

AssemblyCopyright 
( 
$str 0
)0 1
]1 2
[ 
assembly 	
:	 

AssemblyTrademark 
( 
$str 
)  
]  !
[ 
assembly 	
:	 

AssemblyCulture 
( 
$str 
) 
] 
[ 
assembly 	
:	 


ComVisible 
( 
false 
) 
] 
[ 
assembly 	
:	 

Guid 
( 
$str 6
)6 7
]7 8
[!! 
assembly!! 	
:!!	 

AssemblyVersion!! 
(!! 
$str!! $
)!!$ %
]!!% &
["" 
assembly"" 	
:""	 

AssemblyFileVersion"" 
("" 
$str"" (
)""( )
]"") *ﬂ
bC:\Users\mike\Desktop\Calidad_ofline\PRUEBAS-MADERERA\SISTEMA\CapaVistaWeb\Utilidades\Encriptar.cs
	namespace 	
MadereraCarocho
 
. 

Utilidades $
{ 
public 

class 
	Encriptar 
{ 
public 
static 
string 
	GetSHA256 &
(& '
string' -
str. 1
)1 2
{		 	
SHA256

 
sha256

 
=

 
SHA256Managed

 )
.

) *
Create

* 0
(

0 1
)

1 2
;

2 3
ASCIIEncoding 
encoding "
=# $
new% (
ASCIIEncoding) 6
(6 7
)7 8
;8 9
byte 
[ 
] 
stream 
= 
null  
;  !
StringBuilder 
sb 
= 
new "
StringBuilder# 0
(0 1
)1 2
;2 3
stream 
= 
sha256 
. 
ComputeHash '
(' (
encoding( 0
.0 1
GetBytes1 9
(9 :
str: =
)= >
)> ?
;? @
for 
( 
int 
i 
= 
$num 
; 
i 
< 
stream  &
.& '
Length' -
;- .
i/ 0
++0 2
)2 3
sb4 6
.6 7
AppendFormat7 C
(C D
$strD L
,L M
streamN T
[T U
iU V
]V W
)W X
;X Y
return 
sb 
. 
ToString 
( 
)  
;  !
} 	
} 
} 