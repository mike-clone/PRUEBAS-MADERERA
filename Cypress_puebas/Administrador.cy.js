

// describe ("Login",()=>{
//      beforeEach(()=>{
//      cy.visit("http://localhost:8081/")
//      cy.get(".contact-info i").find('a').should("have.text","omarlujan.h@gmail.com")
//     })
//     Cypress.on('uncaught:exception', (err, runnable) => {
//         // Devuelve false para evitar que Cypress falle la prueba
//         return false;
//       });
//     it("Login incorrecto",()=>{
//         cy.get("#navbar ul li").eq(2).click()
//         cy.get(".login-container").find('h1').should("have.text","Login Form")
//         cy.get(".btn").click()
//         cy.get('.needs-validation').should('have.class', 'was-validated'); 
//         cy.get('.invalid-feedback').should('be.visible')
//         cy.get("#valid_username").type("omar@upn.pe")
//         cy.get("#valid_password").type("123")
//         cy.get(".btn").click()
//         cy.get(".alert-danger").should('be.visible')
//         cy.get("#valid_username").type("omar@hotmail.com")
//         cy.get("#valid_password").type("&*")
//         cy.get(".btn").click()
//         cy.get(".alert-danger").should('be.visible')
//         cy.get("#valid_username").type("omarlux@outlook.es")
//         cy.get("#valid_password").type("mms")
//         cy.get(".btn").click()
//         cy.get(".alert-danger").should('be.visible')
//     })
//     it("Login correcto",()=>{
//      cy.get("#navbar ul li").eq(2).click()
//      cy.get(".login-container").find('h1').should("have.text","Login Form")
//      cy.get("#valid_username").type("omar@gmail.com")
//      cy.get("#valid_password").type("123")
//      cy.get(".btn").click()
//      cy.get(".contact-info i").find('a').should("have.text","omar@gmail.com")
//     })
// });
// describe("producto",()=>{
//   beforeEach(()=>{
//     cy.logInAdmin("http://localhost:8081/","omar@gmail.com","123")
//   })
//   it("crear producto incorrectamente",()=>{
//     cy.get("#navbar ul li.dropdown").first().find('ul li').first().find('a').click({force:true})
//     cy.contains("LISTADO DE PRODUCTOS").should("have.text","LISTADO DE PRODUCTOS")

//     cy.contains("Agregar Producto").click({force:true})
//     cy.get("#cTipo").select("2")
//     cy.get("#nombre").type("producto 1")
//     cy.get("#longitud").type("caracter")
//     cy.get("#diametro").type("caracter")
//     cy.get("#precioventa").type("100")
//     cy.contains("Registrar").click()
//     cy.contains("Oops...").should("have.text","Oops...")
//     cy.contains("OK").click()

//     cy.get("#cTipo").select("2")
//     cy.get("#nombre").clear().type("producto 2")
//     cy.get('#longitud').then($input => {
//       $input.val('caracter force');
//       $input.trigger('input');
//     });
//     cy.get('#diametro').then($input => {
//       $input.val('caracter force');
//       $input.trigger('input');
//     });
//     cy.get("#precioventa").clear().type("200")
//     cy.contains("Registrar").click()
//     cy.contains("Oops...").should("have.text","Oops...")
//     cy.contains("OK").click()
//   });
//   it("crear producto,Buscar y Eliminar",()=>{
//     cy.get("#navbar ul li.dropdown").first().find('ul li').first().find('a').click({force:true})
//     cy.contains("LISTADO DE PRODUCTOS").should("have.text","LISTADO DE PRODUCTOS")

//     cy.contains("Agregar Producto").click({force:true})
//     cy.get("#cTipo").select("2")
//     cy.get("#nombre").type("producto 1")
//     cy.get("#longitud").type("7.5")
//     cy.get("#diametro").type("2.5")
//     cy.get("#precioventa").type("100")
//     cy.contains("Registrar").click()
//     cy.get(".swal2-confirm").click()
//     cy.contains("OK").click()

//     cy.get("#Bproducto input").focus().type("producto 1")
//     cy.get("#Bproducto input").type("{enter}")
//     cy.wait(1000)
//     //asert que el producto 1 fue encontrado
//     //cy.get(".table-hover tbody tr").first().find('td').eq(1).should("have.text","producto 1")
//     cy.get(".table-hover tbody tr")
//   .first().find('td').eq(1).invoke('text')
//    .then((text) => {
//     const trimmedText = text.trim();
//     expect(trimmedText).to.equal("producto 1");
//   });
  
//     cy.get(".table-hover tbody tr").first().find('td').eq(9).find('a').first().click({force:true})
//     cy.get(".swal2-confirm").click()
//     cy.contains("OK").click()

//     cy.get("#Bproducto input").focus().type("producto 1")
//     cy.get("#Bproducto input").type("{enter}")
//     cy.wait(1000)
//     // assert que no haya tr en .table-hover tbody
//     cy.get(".table-hover tbody tr").should("not.exist")
//     cy.get("#Bproducto input").focus().clear()
//     cy.get("#Bproducto input").type("{enter}")
    
//   });
// })
describe("Reaaliar Pedido",()=>{
  beforeEach(()=>{
    cy.logInAdmin("http://localhost:8081/","omar@gmail.com","123")
  })
  it("agregar producto al carrito",()=>{
    cy.get("#navbar ul li.dropdown").first().find('ul li').last().find('a').click({force:true})
    cy.contains("LISTADO DE PRODUCTOS").should("have.text","LISTADO DE PRODUCTOS")

    cy.get("#Bproducto input").focus().type("juan")
    cy.get("#Bproducto input").type("{enter}")
    cy.wait(1000)
   
    cy.get(".table-hover tbody tr").should('have.length', 5);
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

    cy.get("#navbar ul li").eq(6).find('a').click({force:true})

  })
})

