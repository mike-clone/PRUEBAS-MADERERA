§ 
RD:\Universidad\calidad\PRUEBAS-MADERERA\SISTEMA\CapaLogica\LogTemporaryProducts.cs
	namespace 	

CapaLogica
 
{ 
public 

class  
LogTemporaryProducts %
{		 
public

 
static

 
readonly

  
LogTemporaryProducts

 3
	_instance

4 =
=

> ?
new

@ C 
LogTemporaryProducts

D X
(

X Y
)

Y Z
;

Z [
public 
static  
LogTemporaryProducts *
	Instancia+ 4
{ 	
get 
{ 
return 
	_instance "
;" #
}$ %
} 	
private !
IDatTemporaryProducts %
TemporaryService& 6
;6 7
public  
LogTemporaryProducts #
(# $
)$ %
{ 	
} 	
public  
LogTemporaryProducts #
(# $!
IDatTemporaryProducts$ 9
ITemporaryP: E
)E F
{ 	
TemporaryService 
= 
ITemporaryP *
;* +
} 	
public 
bool #
CreaarTemporaryProducts +
(+ , 
EntTemporaryProducts, @
tempA E
)E F
{ 	
return 
TemporaryService #
.# $#
CreaarTemporaryProducts$ ;
(; <
temp< @
)@ A
;A B
}   	
public!! 
bool!! &
CreaarTemporaryProductsCli!! .
(!!. / 
EntTemporaryProducts!!/ C
temp!!D H
)!!H I
{"" 	
return## 
TemporaryService## #
.### $&
CreaarTemporaryProductsCli##$ >
(##> ?
temp##? C
)##C D
;##D E
}$$ 	
public&& 
List&& 
<&&  
EntTemporaryProducts&& (
>&&( )$
MostrarTemporaryProducts&&* B
(&&B C
int&&C F
	idUsuario&&G P
)&&P Q
{'' 	
return(( 
TemporaryService(( #
.((# $$
MostrarTemporaryProducts(($ <
(((< =
	idUsuario((= F
)((F G
;((G H
})) 	
public** 
List** 
<**  
EntTemporaryProducts** (
>**( )'
MostrarTemporaryProductsCli*** E
(**E F
int**F I
	idUsuario**J S
)**S T
{++ 	
return,, 
TemporaryService,, #
.,,# $'
MostrarTemporaryProductsCli,,$ ?
(,,? @
	idUsuario,,@ I
),,I J
;,,J K
}-- 	
public.. 
bool.. %
EliminarTemporaryProducts.. -
(..- .
int... 1
id..2 4
)..4 5
{// 	
return00 
TemporaryService00 #
.00# $%
EliminarTemporaryProducts00$ =
(00= >
id00> @
)00@ A
;00A B
}11 	
public22 
bool22 '
ActualizarTemporaryProducts22 /
(22/ 0 
EntTemporaryProducts220 D
temp22E I
)22I J
{33 	
return44 
TemporaryService44 #
.44# $'
ActualizarTemporaryProducts44$ ?
(44? @
temp44@ D
)44D E
;44E F
}55 	
public66  
EntTemporaryProducts66 #%
BuscarTemporaryProductsId66$ =
(66= >
int66> A
id66B D
)66D E
{77 	
return88 
TemporaryService88 #
.88# $%
BuscarTemporaryProductsId88$ =
(88= >
id88> @
)88@ A
;88A B
}99 	
public::  
EntTemporaryProducts:: #(
BuscarTemporaryProductsIdCli::$ @
(::@ A
int::A D
id::E G
)::G H
{;; 	
return<< 
TemporaryService<< #
.<<# $(
BuscarTemporaryProductsIdCli<<$ @
(<<@ A
id<<A C
)<<C D
;<<D E
}== 	
}>> 
}?? µ9
HD:\Universidad\calidad\PRUEBAS-MADERERA\SISTEMA\CapaLogica\LogUsuario.cs
	namespace 	

CapaLogica
 
{		 
public

 

class

 

LogUsuario

 
{ 
public 

LogUsuario 
( 
) 
{ 	
} 	
private 
IDatUsuario 
UsuarioService *
;* +
public 

LogUsuario 
( 
IDatUsuario %
IUsuario& .
). /
{ 	
UsuarioService 
= 
IUsuario %
;% &
} 	
public 
bool 
CrearClientes !
(! "

EntUsuario" ,
usuario- 4
)4 5
{ 	
var 
error 
= 
string 
. 
Empty "
;" #
bool 
isValid 
= 
ValidatorHelper *
.* +
TryValidateEntity+ <
(< =
usuario= D
,D E
outF I
ListJ N
<N O
stringO U
>U V
detalleDeErrorW e
)e f
;f g
var 
detalleerrors 
= 
ValidatorHelper  /
./ 0
aString0 7
(7 8
detalleDeError8 F
)F G
;G H
bool 
creado 
= 
false 
;  
try 
{ 
if 
( 
isValid 
) 
{   
creado!! 
=!! 
UsuarioService!! (
.!!( )
CrearCliente!!) 5
(!!5 6
usuario!!6 =
)!!= >
;!!> ?
}"" 
else## 
{$$ 
error%% 
=%% 
$str%% ?
;%%? @
throw&& 
new&& 
	Exception&& '
(&&' (
error&&( -
)&&- .
;&&. /
}'' 
})) 
catch** 
(** 
	Exception** 
e** 
)** 
{++ 
throw,, 
new,, 
	Exception,, #
(,,# $
e,,% &
.,,& '
Message,,' .
+--$ %
$str--& )
+..$ %
$str..& *
+//$ %
$str//& 8
+00$ %
$str00& *
+11$ %
$str11& )
+22$ %
detalleerrors22& 3
)223 4
;224 5
}33 
return44 
creado44 
;44 
}55 	
public66 
List66 
<66 

EntUsuario66 
>66 
ListarClientes66  .
(66. /
)66/ 0
{77 	
return88 
UsuarioService88 !
.88! "
ListarCliente88" /
(88/ 0
)880 1
;881 2
}99 	
public;; 
List;; 
<;; 

EntUsuario;; 
>;; 
BuscarClientes;;  .
(;;. /
string;;/ 5
dato;;6 :
);;: ;
{<< 	
return== 
UsuarioService== !
.==! "
BuscarCliente==" /
(==/ 0
dato==0 4
)==4 5
;==5 6
}>> 	
public@@ 
bool@@ 
EliminarUsuarios@@ $
(@@$ %
int@@% (
id@@) +
)@@+ ,
{AA 	
returnBB 
UsuarioServiceBB !
.BB! "
EliminarUsuariosBB" 2
(BB2 3
idBB3 5
)BB5 6
;BB6 7
}CC 	
publicEE 
boolEE 
EditarClienteEE !
(EE! "

EntUsuarioEE" ,
uEE- .
)EE. /
{FF 	
returnGG 
UsuarioServiceGG !
.GG! "
EditarClienteGG" /
(GG/ 0
uGG0 1
)GG1 2
;GG2 3
}HH 	
publicLL 
ListLL 
<LL 

EntUsuarioLL 
>LL !
ListarAdministradoresLL  5
(LL5 6
)LL6 7
{MM 	
returnNN 
UsuarioServiceNN !
.NN! "!
ListarAdministradoresNN" 7
(NN7 8
)NN8 9
;NN9 :
}OO 	
publicPP 
boolPP #
ActualizarAdministradorPP +
(PP+ ,

EntUsuarioPP, 6
adPP7 9
)PP9 :
{QQ 	
returnRR 
UsuarioServiceRR !
.RR! "#
ActualizarAdministradorRR" 9
(RR9 :
adRR: <
)RR< =
;RR= >
}SS 	
publicTT 
ListTT 
<TT 

EntUsuarioTT 
>TT !
BuscarAdministradoresTT  5
(TT5 6
stringTT6 <
datoTT= A
)TTA B
{UU 	
returnVV 
UsuarioServiceVV !
.VV! ""
BuscaraAdministradoresVV" 8
(VV8 9
datoVV9 =
)VV= >
;VV> ?
}WW 	
public\\ 

EntUsuario\\ 
BuscarIdUsuario\\ )
(\\) *
int\\* -
	idCliente\\. 7
)\\7 8
{]] 	
return^^ 
UsuarioService^^ !
.^^! "
BuscarIdUsuario^^" 1
(^^1 2
	idCliente^^2 ;
)^^; <
;^^< =
}__ 	
publicaa 

EntUsuarioaa 
IniciarSesionaa '
(aa' (
stringaa( .
datoaa/ 3
,aa3 4
stringaa5 ;
contraaa< B
)aaB C
{bb 	

EntUsuariocc 
ucc 
=cc 
nullcc 
;cc  
vardd 
errordd 
=dd 
stringdd 
.dd 
Emptydd "
;dd" #
tryee 
{ff 
ifgg 
(gg 
DateTimegg 
.gg 
Nowgg  
.gg  !
Hourgg! %
>gg& '
$numgg( *
)gg* +
{hh 
errorii 
=ii 
$strii ;
;ii; <
throwjj 
newjj 
	Exceptionjj '
(jj' (
)jj( )
;jj) *
}kk 
elsell 
{mm 
unn 
=nn 
UsuarioServicenn &
.nn& '
IniciarSesionnn' 4
(nn4 5
datonn5 9
,nn9 :
contrann; A
)nnA B
;nnB C
ifoo 
(oo 
uoo 
!=oo 
nulloo !
)oo! "
{pp 
ifqq 
(qq 
!qq 
uqq 
.qq 
Activoqq %
)qq% &
{rr 
errorss !
=ss" #
$strss$ B
;ssB C
throwtt !
newtt" %
	Exceptiontt& /
(tt/ 0
)tt0 1
;tt1 2
}uu 
}ww 
elsexx 
{yy 
errorzz 
=zz 
$strzz  B
;zzB C
throw{{ 
new{{ !
	Exception{{" +
({{+ ,
){{, -
;{{- .
}|| 
}~~ 
}
€€ 
catch
 
{
 
throw
ƒƒ 
new
ƒƒ 
	Exception
ƒƒ #
(
ƒƒ# $
error
ƒƒ$ )
)
ƒƒ) *
;
ƒƒ* +
}
„„ 
return
…… 
u
…… 
;
…… 
}
†† 	
}
ˆˆ 
}‰‰ ¤
GD:\Universidad\calidad\PRUEBAS-MADERERA\SISTEMA\CapaLogica\LogCompra.cs
	namespace 	

CapaLogica
 
{ 
public		 

class		 
	LogCompra		 
{

 
private 

IDatCompra 
CompraService (
;( )
public 
	LogCompra 
( 
) 
{ 	
} 	
public 
	LogCompra 
( 

IDatCompra #
ICompra$ +
)+ ,
{ 	
CompraService 
= 
ICompra #
;# $
} 	
public 
int 
CrearCompra 
( 
	EntCompra (
comp) -
)- .
{ 	
return 
CompraService  
.  !
CrearCompra! ,
(, -
comp- 1
)1 2
;2 3
} 	
public 
List 
< 
	EntCompra 
> 
ListarCompra +
(+ ,
int, /
id0 2
)2 3
{ 	
return 
CompraService  
.  !
ListarCompra! -
(- .
id. 0
)0 1
;1 2
} 	
public 
List 
< 
	EntCompra 
> !
ListartodasLasCompras 4
(4 5
)5 6
{ 	
return   
CompraService    
.    !!
ListarTodasLasCompras  ! 6
(  6 7
)  7 8
;  8 9
}!! 	
public"" 
bool"" 
EliminarCompra"" "
(""" #
int""# &
comp""' +
)""+ ,
{## 	
return$$ 
CompraService$$  
.$$  !
EliminarCompra$$! /
($$/ 0
comp$$0 4
)$$4 5
;$$5 6
}%% 	
public'' 
List'' 
<'' 
	EntCompra'' 
>'' 
BuscarCompra'' +
(''+ ,
string'', 2
busqueda''3 ;
)''; <
{(( 	
return)) 
CompraService))  
.))  !
BuscarCompra))! -
())- .
busqueda)). 6
)))6 7
;))7 8
}** 	
}++ 
},, ÷

JD:\Universidad\calidad\PRUEBAS-MADERERA\SISTEMA\CapaLogica\LogDetCompra.cs
	namespace 	

CapaLogica
 
{ 
public		 

class		 
LogDetCompra		 
{

 
private 
IDatDetCompra 
DetCompraService .
;. /
public 
LogDetCompra 
( 
) 
{ 	
} 	
public 
LogDetCompra 
( 
IDatDetCompra )
idatdetcompra* 7
)7 8
{ 	
DetCompraService 
= 
idatdetcompra +
;+ ,
} 	
public 
bool 
CrearDetCompra "
(" #
EntDetCompra# /
comp0 4
)4 5
{ 	
return 
DetCompraService #
.# $
CrearDetCompra$ 2
(2 3
comp3 7
)7 8
;8 9
} 	
public 
List 
< 
EntDetCompra  
>  !"
MostrarDetalleCompraId" 8
(8 9
int9 <
id= ?
)? @
{ 	
return 
DetCompraService #
.# $"
MostrarDetalleCompraId$ :
(: ;
id; =
)= >
;> ?
} 	
} 
}   ‘
ID:\Universidad\calidad\PRUEBAS-MADERERA\SISTEMA\CapaLogica\LogDetVenta.cs
	namespace 	

CapaLogica
 
{ 
public 

class 
LogDetVenta 
{ 
private		 
static		 
readonly		 
LogDetVenta		  +

_instancia		, 6
=		7 8
new		9 <
LogDetVenta		= H
(		H I
)		I J
;		J K
public 
static 
LogDetVenta !
	Instancia" +
{ 	
get 
{ 
return 

_instancia #
;# $
}% &
} 	
private 
IDatDetVenta 
DetVentaService ,
;, -
public 
LogDetVenta 
( 
) 
{ 	
} 	
public 
LogDetVenta 
( 
IDatDetVenta '
	IDetVenta( 1
)1 2
{ 	
DetVentaService 
= 
	IDetVenta '
;' (
} 	
public 
bool 
CrearDetVenta !
(! "
EntDetVenta" -
det. 1
)1 2
{ 	
return 
DetVentaService "
." #
CrearDetVenta# 0
(0 1
det1 4
)4 5
;5 6
} 	
public## 
List## 
<## 
EntDetVenta## 
>##  
Mostrardetventa##! 0
(##0 1
int##1 4
idVenta##5 <
)##< =
{$$ 	
return%% 
DetVentaService%% "
.%%" #
Mostrardetventa%%# 2
(%%2 3
idVenta%%3 :
)%%: ;
;%%; <
}&& 	
}(( 
})) Ö
ID:\Universidad\calidad\PRUEBAS-MADERERA\SISTEMA\CapaLogica\LogProducto.cs
	namespace 	

CapaLogica
 
{ 
public		 

class		 
LogProducto		 
{

 
private 
static 
readonly 
LogProducto  +

_instancia, 6
=7 8
new9 <
LogProducto= H
(H I
)I J
;J K
public 
static 
LogProducto !
	Instancia" +
{ 	
get 
{ 
return 

_instancia #
;# $
}% &
} 	
private 
IDatProducto 
ProductoService ,
;, -
public 
LogProducto 
( 
) 
{ 	
} 	
public 
LogProducto 
( 
IDatProducto '
	IProducto( 1
)1 2
{ 	
ProductoService 
= 
	IProducto '
;' (
} 	
public 
bool 
CrearProducto !
(! "
EntProducto" -
prod. 2
)2 3
{   	
return"" 
ProductoService"" $
.""$ %
CrearProducto""% 2
(""2 3
prod""3 7
)""7 8
;""8 9
}$$ 	
public%% 
List%% 
<%% 
EntProducto%% 
>%%  
ListarProducto%%! /
(%%/ 0
)%%0 1
{&& 	
return'' 
ProductoService'' "
.''" #
ListarProducto''# 1
(''1 2
)''2 3
;''3 4
}(( 	
public)) 
bool)) 
ActualizarProducto)) &
())& '
EntProducto))' 2
Prod))3 7
)))7 8
{** 	
return++ 
ProductoService++ "
.++" #
ActualizarProducto++# 5
(++5 6
Prod++6 :
)++: ;
;++; <
},, 	
public.. 
bool.. 
EliminarProducto.. $
(..$ %
int..% (
id..) +
)..+ ,
{// 	
return00 
ProductoService00 "
.00" #
EliminarProducto00# 3
(003 4
id004 6
)006 7
;007 8
}11 	
public22 
List22 
<22 
EntProducto22 
>22  
BuscarProducto22! /
(22/ 0
string220 6
busqueda227 ?
)22? @
{33 	
return44 
ProductoService44 "
.44" #
BuscarProducto44# 1
(441 2
busqueda442 :
)44: ;
;44; <
}55 	
public66 
EntProducto66 
BuscarProductoId66 +
(66+ ,
int66, /
idprod660 6
)666 7
{77 	
return88 
ProductoService88 "
.88" #
BuscarProductoId88# 3
(883 4
(884 5
int885 8
)888 9
idprod889 ?
)88? @
;88@ A
}99 	
}?? 
}@@ —8
JD:\Universidad\calidad\PRUEBAS-MADERERA\SISTEMA\CapaLogica\LogProveedor.cs
	namespace 	

CapaLogica
 
{ 
public		 

class		 
LogProveedor		 
{

 
private 
static 
readonly 
LogProveedor  ,

_instancia- 7
=8 9
new: =
LogProveedor> J
(J K
)K L
;L M
public 
static 
LogProveedor "
	Instancia# ,
{ 	
get 
{ 
return 

_instancia #
;# $
}% &
} 	
private 
IDatProveedor 
ProveedorService .
;. /
public 
LogProveedor 
( 
) 
{ 	
} 	
public 
LogProveedor 
( 
IDatProveedor )

IProveedor* 4
)4 5
{ 	
ProveedorService 
= 

IProveedor )
;) *
} 	
public 
bool 
CrearProveedor "
(" #
EntProveedor# /
pro0 3
)3 4
{ 	
var 
error 
= 
string 
. 
Empty $
;$ %
bool   
isValid   
=   
ValidatorHelper   (
.  ( )
TryValidateEntity  ) :
(  : ;
pro  ; >
,  > ?
out  @ C
List  D H
<  H I
string  I O
>  O P
detalleDeError  Q _
)  _ `
;  ` a
var!! 
detalleerrors!! 
=!! 
ValidatorHelper!!  /
.!!/ 0
aString!!0 7
(!!7 8
detalleDeError!!8 F
)!!F G
;!!G H
bool"" 
creado"" 
="" 
false"" 
;""  
try## 
{$$ 
if%% 
(%% 
isValid%% 
)%% 
{&& 
creado'' 
='' 
ProveedorService'' ,
.'', -
CrearProveedor''- ;
(''; <
pro''< ?
)''? @
;''@ A
}(( 
else)) 
{** 
error++ 
=++ 
$str++ ?
;++? @
throw,, 
new,, 
	Exception,, '
(,,' (
error,,( -
),,- .
;,,. /
}-- 
}11 
catch22 
(22 
	Exception22 
e22 
)22 
{33 
throw44 
new44 
	Exception44 #
(44# $
e44$ %
.44% &
Message44& -
+553 4
$str555 8
+663 4
$str665 9
+773 4
$str775 G
+883 4
$str885 9
+993 4
$str995 8
+::3 4
detalleerrors::5 B
)::B C
;::C D
};; 
return<< 
creado<< 
;<< 
}== 	
public>> 
List>> 
<>> 
EntProveedor>>  
>>>  !
ListarProveedor>>" 1
(>>1 2
)>>2 3
{?? 	
return@@ 
ProveedorService@@ #
.@@# $
ListarProveedor@@$ 3
(@@3 4
)@@4 5
;@@5 6
}AA 	
publicBB 
ListBB 
<BB 
EntProveedorBB  
>BB  !
SelectListProveedorBB" 5
(BB5 6
)BB6 7
{CC 	
returnDD 
ProveedorServiceDD #
.DD# $
SelectListProveedorDD$ 7
(DD7 8
)DD8 9
;DD9 :
}EE 	
publicFF 
ListFF 
<FF 
EntProveedorFF  
>FF  !"
SelectListProveedordatFF" 8
(FF8 9
intFF9 <
idFF= ?
)FF? @
{GG 	
returnII 
ProveedorServiceII #
.II# $"
SelectListProveedordatII$ :
(II: ;
idII; =
)II= >
;II> ?
}JJ 	
publicKK 
boolKK 
ActualizarProveedorKK '
(KK' (
EntProveedorKK( 4
proKK5 8
)KK8 9
{LL 	
varMM 
errorMM 
=MM 
stringMM 
.MM 
EmptyMM $
;MM$ %
boolNN 
isValidNN 
=NN 
ValidatorHelperNN *
.NN* +
TryValidateEntityNN+ <
(NN< =
proNN= @
,NN@ A
outNNB E
ListNNF J
<NNJ K
stringNNK Q
>NNQ R
detalleDeErrorNNS a
)NNa b
;NNb c
varOO 
detalleerrorsOO 
=OO 
ValidatorHelperOO  /
.OO/ 0
aStringOO0 7
(OO7 8
detalleDeErrorOO8 F
)OOF G
;OOG H
boolPP 
actualizadoPP 
=PP 
falsePP $
;PP$ %
tryQQ 
{RR 
ifSS 
(SS 
isValidSS 
)SS 
{TT 
actualizadoUU 
=UU  
ProveedorServiceUU! 1
.UU1 2
ActualizarProveedorUU2 E
(UUE F
proUUF I
)UUI J
;UUJ K
}VV 
elseWW 
{XX 
errorYY 
=YY 
$strYY ?
;YY? @
throwZZ 
newZZ 
	ExceptionZZ '
(ZZ' (
errorZZ( -
)ZZ- .
;ZZ. /
}[[ 
}\\ 
catch]] 
(]] 
	Exception]] 
e]] 
)]] 
{^^ 
throw__ 
new__ 
	Exception__ #
(__# $
e__$ %
.__% &
Message__& -
+``4 5
$str``6 9
+aa4 5
$straa6 :
+bb4 5
$strbb6 H
+cc4 5
$strcc6 :
+dd4 5
$strdd6 9
+ee4 5
detalleerrorsee6 C
)eeC D
;eeD E
}ff 
returngg 
actualizadogg 
;gg 
}hh 	
publicii 
boolii 
EliminarProveedorii %
(ii% &
intii& )
idii* ,
)ii, -
{jj 	
returnkk 
ProveedorServicekk #
.kk# $
EliminarProveedorkk$ 5
(kk5 6
idkk6 8
)kk8 9
;kk9 :
}ll 	
publicoo 
Listoo 
<oo 
EntProveedoroo  
>oo  !
BuscarProveedoroo" 1
(oo1 2
stringoo2 8
busquedaoo9 A
)ooA B
{pp 	
returnqq 
ProveedorServiceqq #
.qq# $
BuscarProveedorqq$ 3
(qq3 4
busquedaqq4 <
)qq< =
;qq= >
}rr 	
publicss 
EntProveedorss 
BuscarIdProveedorss -
(ss- .
intss. 1
idProveedorss2 =
)ss= >
{tt 	
returnuu 
ProveedorServiceuu #
.uu# $
BuscarIdProveedoruu$ 5
(uu5 6
idProveedoruu6 A
)uuA B
;uuB C
}vv 	
}ww 
}xx û
RD:\Universidad\calidad\PRUEBAS-MADERERA\SISTEMA\CapaLogica\LogProveedorProducto.cs
	namespace 	

CapaLogica
 
{ 
public		 

class		  
LogProveedorProducto		 %
{

 
private 
static 
readonly  
LogProveedorProducto  4

_instancia5 ?
=@ A
newB E 
LogProveedorProductoF Z
(Z [
)[ \
;\ ]
public 
static  
LogProveedorProducto *
	Instancia+ 4
{ 	
get 
{ 
return 

_instancia #
;# $
}% &
} 	
private !
IDatProveedorProducto %$
ProveedorProductoService& >
;> ?
public  
LogProveedorProducto #
(# $
)$ %
{ 	
} 	
public  
LogProveedorProducto #
(# $!
IDatProveedorProducto$ 9
IProveedorProducto: L
)L M
{ 	$
ProveedorProductoService $
=% &
IProveedorProducto' 9
;9 :
} 	
public 
bool "
CrearProveedorProducto *
(* + 
EntProveedorProducto+ ?
prod@ D
)D E
{ 	
return $
ProveedorProductoService +
.+ ,"
CrearProveedorProducto, B
(B C
prodC G
)G H
;H I
}!! 	
public"" 
List"" 
<""  
EntProveedorProducto"" (
>""( )%
ListarProductoParaComprar""* C
(""C D
)""D E
{## 	
return$$ $
ProveedorProductoService$$ +
.$$+ ,%
ListarProductoParaComprar$$, E
($$E F
)$$F G
;$$G H
}%% 	
public'' 
List'' 
<''  
EntProveedorProducto'' (
>''( )$
MostrarDetalleProvedorId''* B
(''B C
int''C F
idProveedor''G R
)''R S
{(( 	
return)) $
ProveedorProductoService)) +
.))+ ,$
MostarDetalleProveedorId)), D
())D E
idProveedor))E P
)))P Q
;))Q R
}** 	
public,, 
List,, 
<,,  
EntProveedorProducto,, (
>,,( )$
MostarDetalleProveedorId,,* B
(,,B C
int,,C F
idProveedor,,G R
),,R S
{-- 	
return.. $
ProveedorProductoService.. +
...+ ,$
MostarDetalleProveedorId.., D
(..D E
idProveedor..E P
)..P Q
;..Q R
}// 	
public00 
List00 
<00  
EntProveedorProducto00 (
>00( )%
BuscarProductoParaComprar00* C
(00C D
string00D J
busqueda00K S
)00S T
{11 	
return22 $
ProveedorProductoService22 +
.22+ ,%
BuscarProductoParaComprar22, E
(22E F
busqueda22F N
)22N O
;22O P
}33 	
public55  
EntProveedorProducto55 #$
BuscarProvedorProductoId55$ <
(55< =
int55= @
idprod55A G
,55G H
int55I L
idprov55M S
)55S T
{66 	
return77 $
ProveedorProductoService77 +
.77+ ,$
BuscarProvedorProductoId77, D
(77D E
idprod77E K
,77K L
idprov77M S
)77S T
;77T U
}88 	
public99 
bool99 $
EliminarDetalleProveedor99 ,
(99, -
int99- 0
prov991 5
,995 6
int997 :
prod99; ?
)99? @
{:: 	
return;; $
ProveedorProductoService;; +
.;;+ ,$
EliminarDetalleProveedor;;, D
(;;D E
prov;;E I
,;;I J
prod;;K O
);;O P
;;;P Q
}<< 	
}?? 
}@@ á
ED:\Universidad\calidad\PRUEBAS-MADERERA\SISTEMA\CapaLogica\logRoll.cs
	namespace 	

CapaLogica
 
{ 
public 

class 
logRoll 
{ 
private		 
static		 
readonly		 
logRoll		  '

_instancia		( 2
=		3 4
new		5 8
logRoll		9 @
(		@ A
)		A B
;		B C
public

 
static

 
logRoll

 
	Instancia

 '
{ 	
get 
{ 
return 

_instancia #
;# $
}% &
} 	
public 
List 
< 
entRoll 
> 
	ListarRol &
(& '
)' (
{ 	
return 
datRoll 
. 
	Instancia $
.$ %

ListarRoll% /
(/ 0
)0 1
;1 2
} 	
} 
} ƒ
MD:\Universidad\calidad\PRUEBAS-MADERERA\SISTEMA\CapaLogica\LogTipoProducto.cs
	namespace 	

CapaLogica
 
{ 
public 

class 
LogTipoProducto  
{		 
private

 
static

 
readonly

 
LogTipoProducto

  /

_instancia

0 :
=

; <
new

= @
LogTipoProducto

A P
(

P Q
)

Q R
;

R S
public 
static 
LogTipoProducto %
	Instancia& /
{ 	
get 
{ 
return 

_instancia #
;# $
}% &
} 	
private 
IDatTipoProducto  
TipoProductoService! 4
;4 5
public 
LogTipoProducto 
( 
)  
{ 	
} 	
public 
LogTipoProducto 
( 
IDatTipoProducto /
ITipoProducto0 =
)= >
{ 	
TipoProductoService 
=  !
ITipoProducto" /
;/ 0
} 	
public 
bool 
CrearTipoProducto %
(% &
EntTipoProducto& 5
tipoProducto6 B
)B C
{ 	
return   
TipoProductoService   &
.  & '
CrearTipoProducto  ' 8
(  8 9
tipoProducto  9 E
)  E F
;  F G
}!! 	
public"" 
List"" 
<"" 
EntTipoProducto"" #
>""# $"
SelectListTipoProducto""% ;
(""; <
)""< =
{## 	
return$$ 
TipoProductoService$$ &
.$$& '"
SelectListTipoProducto$$' =
($$= >
)$$> ?
;$$? @
}%% 	
public&& 
List&& 
<&& 
EntTipoProducto&& #
>&&# $%
SelectListTipoProductodat&&% >
(&&> ?
int&&? B
id&&C E
)&&E F
{'' 	
return(( 
TipoProductoService(( &
.((& '%
SelectListTipoProductodat((' @
(((@ A
id((A C
)((C D
;((D E
})) 	
public** 
bool** "
ActualizarTipoProducto** *
(*** +
EntTipoProducto**+ :
tipoProducto**; G
)**G H
{++ 	
return,, 
TipoProductoService,, &
.,,& '"
ActualizarTipoProducto,,' =
(,,= >
tipoProducto,,> J
),,J K
;,,K L
}-- 	
public.. 
bool..  
EliminarTipoProducto.. (
(..( )
int..) ,
id..- /
)../ 0
{// 	
return00 
TipoProductoService00 &
.00& ' 
EliminarTipoProducto00' ;
(00; <
id00< >
)00> ?
;00? @
}11 	
}44 
}55 Ê
GD:\Universidad\calidad\PRUEBAS-MADERERA\SISTEMA\CapaLogica\LogUbigeo.cs
	namespace 	

CapaLogica
 
{ 
public 

class 
	LogUbigeo 
{		 
private

 
static

 
readonly

 
	LogUbigeo

  )

_instancia

* 4
=

5 6
new

7 :
	LogUbigeo

; D
(

D E
)

E F
;

F G
public 
static 
	LogUbigeo 
	Instancia  )
{ 	
get 
{ 
return 

_instancia #
;# $
}% &
} 	
private 

IDatUbigeo 
UbigeoService (
;( )
public 
	LogUbigeo 
( 
) 
{ 	
} 	
public 
	LogUbigeo 
( 

IDatUbigeo #
IUbigeo$ +
)+ ,
{ 	
UbigeoService 
= 
IUbigeo #
;# $
} 	
public 
bool 
CrearUbigeo 
(  
	EntUbigeo  )
u* +
)+ ,
{ 	
return 
UbigeoService  
.  !
CrearUbigeo! ,
(, -
u- .
). /
;/ 0
} 	
public   
List   
<   
	EntUbigeo   
>   
ListarUbigeo   +
(  + ,
)  , -
{!! 	
return"" 
UbigeoService""  
.""  !
ListarUbigeo""! -
(""- .
)"". /
;""/ 0
}## 	
public$$ 
bool$$ 
ActualizarUbigeo$$ $
($$$ %
	EntUbigeo$$% .
u$$/ 0
)$$0 1
{%% 	
return&& 
UbigeoService&&  
.&&  !
ActualizarUbigeo&&! 1
(&&1 2
u&&2 3
)&&3 4
;&&4 5
}'' 	
public(( 
bool(( 
EliminarUbigeo(( "
(((" #
int((# &
id((' )
)(() *
{)) 	
return** 
UbigeoService**  
.**  !
EliminarUbigeo**! /
(**/ 0
id**0 2
)**2 3
;**3 4
}++ 	
public,, 
List,, 
<,, 
	EntUbigeo,, 
>,, 
ListarDistrito,, -
(,,- .
),,. /
{-- 	
return.. 
UbigeoService..  
...  !
ListarDistrito..! /
(../ 0
)..0 1
;..1 2
}// 	
public00 
List00 
<00 
	EntUbigeo00 
>00 
BuscarUbigeo00 +
(00+ ,
string00, 2
busqueda003 ;
)00; <
{11 	
return22 
UbigeoService22  
.22  !
BuscarUbigeo22! -
(22- .
busqueda22. 6
)226 7
;227 8
}33 	
}55 
}66 ƒ
FD:\Universidad\calidad\PRUEBAS-MADERERA\SISTEMA\CapaLogica\LogVenta.cs
	namespace 	

CapaLogica
 
{ 
public		 

class		 
LogVenta		 
{

 
private 
static 
readonly 
LogVenta  (

_instancia) 3
=4 5
new6 9
LogVenta: B
(B C
)C D
;D E
public 
static 
LogVenta 
	Instancia (
{ 	
get 
{ 
return 

_instancia #
;# $
}% &
} 	
private 
	IDatVenta 
VentaService &
;& '
public 
LogVenta 
( 
) 
{ 	
} 	
public 
LogVenta 
( 
	IDatVenta !
IVenta" (
)( )
{ 	
VentaService 
= 
IVenta !
;! "
} 	
public 
int 

CrearVenta 
( 
EntVenta &
v' (
)( )
{ 	
return   
VentaService   
.    

CrearVenta    *
(  * +
v  + ,
)  , -
;  - .
}!! 	
public"" 
List"" 
<"" 
EntVenta"" 
>"" 
ListarVenta"" )
("") *
int""* -
id"". 0
)""0 1
{## 	
return$$ 
VentaService$$ 
.$$  
ListarVenta$$  +
($$+ ,
id$$, .
)$$. /
;$$/ 0
}%% 	
public&& 
List&& 
<&& 
EntVenta&& 
>&& 
ListarTodasLasVenta&& 1
(&&1 2
)&&2 3
{'' 	
return(( 
VentaService(( 
.((  
ListarTodasLasVenta((  3
(((3 4
)((4 5
;((5 6
})) 	
}66 
}77 €
UD:\Universidad\calidad\PRUEBAS-MADERERA\SISTEMA\CapaLogica\Properties\AssemblyInfo.cs
[ 
assembly 	
:	 

AssemblyTitle 
( 
$str %
)% &
]& '
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
$str '
)' (
]( )
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
["" 
assembly"" 	
:""	 

AssemblyVersion"" 
("" 
$str"" $
)""$ %
]""% &
[## 
assembly## 	
:##	 

AssemblyFileVersion## 
(## 
$str## (
)##( )
]##) *«
MD:\Universidad\calidad\PRUEBAS-MADERERA\SISTEMA\CapaLogica\ValidatorHelper.cs
	namespace 	

CapaLogica
 
{ 
public 

class 
ValidatorHelper  
{		 
public

 
static

 
bool

 
TryValidateEntity

 ,
<

, -
T

- .
>

. /
(

/ 0
T

0 1
entity

2 8
,

8 9
out

: =
List

> B
<

B C
string

C I
>

I J
lista

J O
)

O P
{

Q R
var 
validationContext 
= 
new  #
ValidationContext$ 5
(5 6
entity6 <
)< =
;= >
var 
validationResults 
= 
new  #
List$ (
<( )
ValidationResult) 9
>9 :
(: ;
); <
;< =
var 
isValid 
= 
	Validator 
.  
TryValidateObject  1
(1 2
entity2 8
,8 9
validationContext: K
,K L
validationResultsM ^
,^ _
true` d
)d e
;e f
lista 
= 
validationResults !
.! "
Select" (
(( )
r) *
=>+ -
r. /
./ 0
ErrorMessage0 <
)< =
.= >
ToList> D
(D E
)E F
;F G
return 
isValid 
; 
} 	
public 
bool 
ValidateNonEmpty $
<$ %
T% &
>& '
(' (
params( .
T/ 0
[0 1
]1 2
values3 9
)9 :
{ 	
foreach 
( 
var 
value 
in !
values" (
)( )
{ 
var 
validationContext %
=& '
new( +
ValidationContext, =
(= >
value> C
)C D
;D E
var 
validationResults %
=& '
new( +
List, 0
<0 1
ValidationResult1 A
>A B
(B C
)C D
;D E
if 
( 
! 
	Validator 
. 
TryValidateObject 0
(0 1
value1 6
,6 7
validationContext8 I
,I J
validationResultsK \
,\ ]
true^ b
)b c
)c d
{ 
return 
false  
;  !
} 
} 
return 
true 
; 
}   	
public"" 
static"" 
string"" 
aString"" $
(""$ %
List""% )
<"") *
string""* 0
>""0 1
lista""1 6
)""6 7
{## 	
string$$ 
errors$$ 
=$$ 
string$$ "
.$$" #
Empty$$# (
;$$( )
foreach%% 
(%% 
var%% 
value%% 
in%%  
lista%%! &
)%%& '
{%%( )
errors&& 
+=&& 
value&& 
;&& 
}'' 
return(( 
errors(( 
;(( 
})) 	
}++ 
},, 