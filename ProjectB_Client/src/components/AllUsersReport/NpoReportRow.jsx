import React, { useState, useEffect } from "react";
import { getAllNpoFromDB } from "../../services/services";

export const NpoReportRow = (props) => {
  const [AllNpo, setAllNpo] = useState([]);

  const getDB = async () => {
    let result = await getNpoFromDB();
    setNpo(result.data);
  };

  useEffect(() => {
    getDB();
  }, []);

  return (
    <>
      {AllNpo.length > 0 ? (
        AllNpo.map((Npo) => {
          let { Name, Email, Image } = Npo;
          return (
            <>
              <tr>
                <td>{Name}</td>
                <td>{Email}</td>
                <td>{Website_URL}</td>
                <td>{Image}</td>
              </tr>
            </>
          );
        })
      ) : (
        <h1>There are no Npo.</h1>
      )}
    </>
  );
};
