import React, { useState, useEffect, useContext } from "react";
import { getAllProductsFromDB } from "../../services/services";
import { addOrderToDB } from "../../services/services";
import { RoleStatus } from "../../context/roleStatus";

export const ProductsReportRow = (props) => {
  const [AllProducts, setAllProducts] = useState([]);
  const { role, setRole } = useContext(RoleStatus);

  const getDB = async () => {
    let result = await getAllProductsFromDB();
    setAllProducts(result.data);
  };

  useEffect(() => {
    getDB();
  }, []);

  const handelDonationData = async (Product) => {
    await addOrderToDB(Product);
  };

  return (
    <>
      {AllProducts.length > 0 ? (
        AllProducts.map((Product) => {
          let { Code, Name, Price, Units_In_Stock, BC_code, Campaign_code, Image } = Product;
          return (
            <>
              <tr>
                <th scope="row">{Code}</th>
                <td>{Name}</td>
                <td>{Price}$</td>
                <td>{Units_In_Stock}</td>
                <td>{BC_code}</td>
                <td>{Campaign_code}</td>
                <td>
                  <img style={{ width: "50px", height: "50px", borderRadius: "30%" }} src={Image} alt="" />
                </td>
                {role === "SA" && (
                  <td>
                    <button type="button" class="btn btn-primary" onClick={() => handelDonationData(Product)}>
                      Buy & Donate
                    </button>
                  </td>
                )}
              </tr>
            </>
          );
        })
      ) : (
        <h1>There are no campaigns.</h1>
      )}
    </>
  );
};
