
  describe ("Login",()=>{
     beforeEach(()=>{
     cy.visit("http://localhost:8081/")
     cy.get(".contact-info i").find('a').should("have.text","omarlujan.h@gmail.com")
    })
    Cypress.on('uncaught:exception', (err, runnable) => {
        // Devuelve false para evitar que Cypress falle la prueba
        return false;
      });
    it("Login incorrecto",()=>{
        cy.get("#navbar ul li").eq(2).click()
        cy.get(".login-container").find('h1').should("have.text","Login Form")
        cy.get(".btn").click()
        cy.get('.needs-validation').should('have.class', 'was-validated'); 
        cy.get('.invalid-feedback').should('be.visible')
        cy.get("#valid_username").type("omar@upn.pe")
        cy.get("#valid_password").type("123")
        cy.get(".btn").click()
        cy.get(".alert-danger").should('be.visible')
        cy.get("#valid_username").type("omar@hotmail.com")
        cy.get("#valid_password").type("&*")
        cy.get(".btn").click()
        cy.get(".alert-danger").should('be.visible')
        cy.get("#valid_username").type("omarlux@outlook.es")
        cy.get("#valid_password").type("mms")
        cy.get(".btn").click()
        cy.get(".alert-danger").should('be.visible')
    })
    it("Login correcto",()=>{
     cy.get("#navbar ul li").eq(2).click()
     cy.get(".login-container").find('h1').should("have.text","Login Form")
     cy.get("#valid_username").type("omar@gmail.com")
     cy.get("#valid_password").type("123")
     cy.get(".btn").click()
     cy.get(".contact-info i").find('a').should("have.text","omar@gmail.com")
    })
});
describe("producto",()=>{
  beforeEach(()=>{
    cy.logInAdmin("http://localhost:8081/","omar@gmail.com","123")
  })
  it("crear producto incorrectamente",()=>{
    cy.get("#navbar ul li.dropdown").first().find('ul li').first().find('a').click({force:true})
    cy.contains("LISTADO DE PRODUCTOS").should("have.text","LISTADO DE PRODUCTOS")

    cy.contains("Agregar Producto").click({force:true})
    cy.get("#cTipo").select("2")
    cy.get("#nombre").type("producto 1")
    cy.get("#longitud").type("caracter")
    cy.get("#diametro").type("caracter")
    cy.get("#precioventa").type("100")
    cy.contains("Registrar").click()
    cy.contains("Oops...").should("have.text","Oops...")
    cy.contains("OK").click()

    cy.get("#cTipo").select("2")
    cy.get("#nombre").clear().type("producto 2")
    cy.get('#longitud').then($input => {
      $input.val('caracter force');
      $input.trigger('input');
    });
    cy.get('#diametro').then($input => {
      $input.val('caracter force');
      $input.trigger('input');
    });
    cy.get("#precioventa").clear().type("200")
    cy.contains("Registrar").click()
    cy.contains("Oops...").should("have.text","Oops...")
    cy.contains("OK").click()
  });
  it("crear producto,Buscar y Eliminar",()=>{
    cy.get("#navbar ul li.dropdown").first().find('ul li').first().find('a').click({force:true})
    cy.contains("LISTADO DE PRODUCTOS").should("have.text","LISTADO DE PRODUCTOS")

    cy.contains("Agregar Producto").click({force:true})
    cy.get("#cTipo").select("2")
    cy.get("#nombre").type("producto 1")
    cy.get("#longitud").type("7.5")
    cy.get("#diametro").type("2.5")
    cy.get("#precioventa").type("100")
    cy.contains("Registrar").click()
    cy.get(".swal2-confirm").click()
    cy.contains("OK").click()

    cy.get("#Bproducto input").focus().type("producto 1")
    cy.get("#Bproducto input").type("{enter}")
    cy.wait(1000)
    //asert que el producto 1 fue encontrado
    cy.get(".table-hover tbody tr")
  .first().find('td').eq(1).invoke('text')
   .then((text) => {
    const trimmedText = text.trim();
    expect(trimmedText).to.equal("producto 1");
  });
   //eliminando producto 1
    cy.get(".table-hover tbody tr").first().find('td').eq(9).find('a').first().click({force:true})
    cy.get(".swal2-confirm").click()
    cy.contains("OK").click()

    cy.get("#Bproducto input").focus().type("producto 1")
    cy.get("#Bproducto input").type("{enter}")
    cy.wait(1000)
    // assert que no haya tr en .table-hover tbody
    cy.get(".table-hover tbody tr").should("not.exist")
    cy.get("#Bproducto input").focus().clear()
    cy.get("#Bproducto input").type("{enter}")
    
  });
})
describe("Pedido",()=>{
  beforeEach(()=>{
    cy.logInAdmin("http://localhost:8081/","omar@gmail.com","123")
  })
  it("agregar producto al carrito,realizar pedido,ver detalle",()=>{

    //guardo la cantidad de pedidos antes de agregar y lo guardo en trCountA
    cy.guardarId().then((trCountA) => {
      //ingreso a la pagina de productos
      cy.get("#navbar ul li.dropdown").first().find('ul li').last().find('a').click({force:true})
      cy.contains("LISTADO DE PRODUCTOS").should("have.text","LISTADO DE PRODUCTOS")
      //filtr por provedor
      cy.get("#Bproducto input").focus().type("juan")
      cy.get("#Bproducto input").type("{enter}")
      cy.wait(1000)
      cy.get(".table-hover tbody tr").should('have.length', 5);
      //elijo el los productos
      cy.get(".table-hover tbody tr").first().find('td').eq(10).find('a').first().click({force:true})
      cy.wait(1000)
      cy.get(".table-hover tbody tr").eq(1).find('td').eq(10).find('a').first().click({force:true})
      cy.wait(1000)
      cy.get(".table-hover tbody tr").eq(2).find('td').eq(10).find('a').first().click({force:true})
      cy.wait(1000)  
      cy.get(".table-hover tbody tr").eq(3).find('td').eq(10).find('a').first().click({force:true})
      cy.wait(1000)
      cy.get(".table-hover tbody tr").eq(4).find('td').eq(10).find('a').first().click({force:true})
      cy.wait(1000)
      //reviso el carrito
      cy.get("#navbar ul li").eq(13).click({froce:true})
      cy.contains("LISTA DE PEDIDO").should("have.text","LISTA DE PEDIDO")
      cy.get(".table-hover tbody tr").should('have.length', 5);
      //realizo el pedido
      cy.get(".btn-success").click({force:true})
      cy.contains("MIS COMPRAS").should("have.text","MIS COMPRAS")
      //verifico si el pedido se realizo comparando trCountA(numero de pedidos antes +1 ) con trCountD(numero de pedidos despues)
      cy.get(".table tbody tr").then((trElements) => {
        const trCountD = trElements.length;
        expect(trCountD).to.equal(trCountA+1);
      });
    });
  });
});

describe("proveedor",()=>{
  beforeEach(()=>{
      cy.logInAdmin("http://localhost:8081/","omar@gmail.com","123")
    })
  it("crear proveedor incorrectamente",()=>{
    cy.get("#navbar ul li").eq(8).find('a').click({force:true})
    cy.contains("LISTADO DE PROVEEDORES").should("have.text","LISTADO DE PROVEEDORES")
    cy.contains("Registrar Proveedor").click({force:true})

    cy.get("#nombre").focus().type("proveedor 1")
    cy.get("#ruc").focus().type("123456789")
    cy.get("#telefono").focus().type("123456789")  
    cy.get("#inputEmail4").focus().type("proveedor1@gmail")
    cy.get("#description").focus().type("descripcion1")
    cy.get("#ubigeo").focus().select(2,{force:true})
    cy.contains("submit").click()
    cy.get(".accordion-body").find('div').first().should("have.text","Es probale que :\n El campo Teléfono debe tener 9 dígitos y comenzar con 9.")
    cy.get(".btn-group-lg").click({force:true})

    cy.get("#nombre").focus().type("proveedor 2")
    cy.get("#ruc").focus().type("923456789")
    cy.get("#telefono").focus().type("923456789")  
    cy.get("#inputEmail4").focus().type("proveedor1gmail")
    cy.get("#description").focus().type("descripcion1")
    cy.get("#ubigeo").focus().select(2,{force:true})
    cy.contains("submit").click()
    cy.get(".accordion-body").find('div').first().should("have.text","Es probale que :\n El campo Correo no es una dirección válida.")
    cy.get(".btn-group-lg").click({force:true})

    cy.get("#nombre").focus().type("proveedor 1")
    cy.get("#ruc").focus().type("123456789")
    cy.get("#telefono").focus().type("923456789")  
    cy.get("#inputEmail4").focus().type("proveedor1@gmail")
    cy.get("#description").focus().type("descripcion1")
    cy.get("#ubigeo").focus().select(2,{force:true})
    cy.contains("submit").click()
    cy.get(".accordion-body").find('div').first().should("have.text","Se terminó la instrucción. \nEs probale que :\n ")
 });
  it("crear proveedor, Buscar y Eliminar",()=>{
    cy.get("#navbar ul li").eq(8).find('a').click({force:true})
    cy.contains("LISTADO DE PROVEEDORES").should("have.text","LISTADO DE PROVEEDORES")

    cy.contains("Registrar Proveedor").click({force:true})
    cy.get("#nombre").focus().type("proveedor1")
    cy.get("#ruc").focus().type("12345678933")
    cy.get("#telefono").focus().type("923456789")  
    cy.get("#inputEmail4").focus().type("proveedor1@gmail")
    cy.get("#description").focus().type("descripcion1")
    cy.get("#ubigeo").focus().select(2,{force:true})
    cy.contains("submit").click()
    
    cy.get("#Bproveedor input").focus().type("proveedor1")
    cy.get("#Bproveedor input").type("{enter}")
    cy.wait(1000)
    //asert que el proveedor 1 fue encontrado
    cy.get(".table tbody tr").should('have.length', 1);
    cy.get(".table tbody tr").find('td').eq(10).find('a').first().click({force:true})
    cy.get(".swal2-confirm").click()
    cy.contains("OK").click()
    cy.get("#Bproveedor input").focus().type("proveedor1")
    cy.get("#Bproveedor input").type("{enter}")
    cy.wait(1000)
    // assert que no haya tr en .table tbody
    cy.get(".table tbody tr").should("not.exist")
    cy.get("#Bproveedor input").focus().clear()
    cy.get("#Bproveedor input").type("{enter}")

  });
  it("crear proveedor, Buscar y Editar",()=>{
    cy.get("#navbar ul li").eq(8).find('a').click({force:true})
    cy.contains("LISTADO DE PROVEEDORES").should("have.text","LISTADO DE PROVEEDORES")

    cy.contains("Registrar Proveedor").click({force:true})
    cy.get("#nombre").focus().type("proveedor2")
    cy.get("#ruc").focus().type("20345678933")
    cy.get("#telefono").focus().type("923456789")  
    cy.get("#inputEmail4").focus().type("proveedor2@gmail")
    cy.get("#description").focus().type("descripcion2")
    cy.get("#ubigeo").focus().select(3,{force:true})
    cy.contains("submit").click()
    cy.get("#Bproveedor input").focus().type("proveedor2")
    cy.get("#Bproveedor input").type("{enter}")
    cy.wait(1000)
    cy.get(".table tbody tr").find('td').eq(9).find('a').first().click({force:true})

    cy.get("#Ubi").select(5,{force:true})
    cy.get("#RazonSocial").focus().clear().type("proveedor3")
    cy.get("#Ruc").focus().clear().type("10345678933")
    cy.get("#Correo").focus().clear().type("proveedor3@gmail")
    cy.get("#Telefono").focus().clear().type("923456789")
    cy.get("#Descripcion").focus().clear().type("descripcion3")
    cy.get(".btn-info").click({force:true})

    cy.get("#Bproveedor input").focus().type("proveedor3")
    cy.get("#Bproveedor input").type("{enter}")
    cy.wait(1000)
    //asert que el proveedor3 fue encontrado
    cy.get(".table tbody tr").should('have.length', 1);
    cy.get(".table tbody tr").find('td').eq(10).find('a').first().click({force:true})
    cy.get(".swal2-confirm").click()
    cy.contains("OK").click()
    cy.get("#Bproveedor input").focus().type("proveedor3")
    cy.get("#Bproveedor input").type("{enter}")
    cy.wait(1000)
    // assert que no haya tr en .table tbody
    cy.get(".table tbody tr").should("not.exist")
    cy.get("#Bproveedor input").focus().clear()
    cy.get("#Bproveedor input").type("{enter}")
    

  })
});
