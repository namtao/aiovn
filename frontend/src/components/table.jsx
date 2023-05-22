/* eslint-disable react-hooks/exhaustive-deps */
/* eslint-disable jsx-a11y/aria-props */
/* eslint-disable jsx-a11y/anchor-is-valid */
/* eslint-disable no-unused-vars */
import React, { useEffect, useState } from "react";

export const Table = () => {
  const [data, setData] = useState([]);

  const [currentPage, setcurrentPage] = useState(1);
  const [itemsPerPage, setitemsPerPage] = useState(10);

  const [pageNumberLimit, setpageNumberLimit] = useState(5);
  const [maxPageNumberLimit, setmaxPageNumberLimit] = useState(5);
  const [minPageNumberLimit, setminPageNumberLimit] = useState(0);
  // const [filterResult, setFilterResult] = useState([]);
  const [searchResult, setSearchResult] = useState("");

  const API = `https://jsonplaceholder.typicode.com/photos`;

  const renderData = (data) => {
    return (
      <>
        <div className="row">
          <div className="col-12">
            <div id="example_filter" className="dataTables_filter">
              <label
                style={{
                  display: "flex",
                  justifyContent: "center",
                  flexWrap: "nowrap",
                  flexDirection: "column",
                }}
              >
                <input
                  type="search"
                  className="form-control form-control-sm"
                  placeholder="Tìm kiếm"
                  aria-controls="example"
                  style={{ height: "3.875rem", fontSize: "1.875rem" }}
                  onChange={(e) => {
                    handleSearch(e);
                  }}
                />
              </label>
            </div>
          </div>
        </div>

        <table
          id="example"
          className="table table-striped table-bordered"
          style={{ width: "100%", margin: "10px" }}
        >
          <thead>
            <tr>
              <th>AlbumId</th>
              <th>ID</th>
              <th>Title</th>
              <th>Url</th>
              <th>Thumbnail Url</th>
            </tr>
          </thead>
          <tbody>
            {/* {searchResult.length > 1
              ? filterResult.map((item, index) => (
                  <tr key={index}>
                    <td>{item.albumId}</td>
                    <td>{item.id}</td>
                    <td>{splitResult(item.title + item.url)}</td>
                    <td>{item.url}</td>
                    <td>{item.thumbnailUrl}</td>
                  </tr>
                ))
              : data.map((item, index) => (
                  <tr key={index}>
                    <td>{item.albumId}</td>
                    <td>{item.id}</td>
                    <td>{item.title}</td>
                    <td>{item.url}</td>
                    <td>{item.thumbnailUrl}</td>
                  </tr>
                ))} */}
            {data.map((item, index) => (
              <tr key={index}>
                <td>{item.albumId}</td>
                <td>{item.id}</td>
                <td>{splitResult(item.title)}</td>
                <td>{splitResult(item.url)}</td>
                <td>{splitResult(item.thumbnailUrl)}</td>
              </tr>
            ))}
          </tbody>
          <tfoot>
            <tr>
              <th>AlbumId</th>
              <th>ID</th>
              <th>Title</th>
              <th>Url</th>
              <th>Thumbnail Url</th>
            </tr>
          </tfoot>
        </table>
      </>
    );
  };

  const handleClick = (event) => {
    // console.log(Number(event.target.id));
    setcurrentPage(Number(event.target.id));
  };

  // hightlight results
  const splitResult = (result) =>
    //Split on search result and then simply style the matches then map through
    result.split(new RegExp(`(${searchResult})`, `gi`)).map((piece, index) => {
      return (
        <span
          key={index}
          style={{
            background:
              piece.toLowerCase() === searchResult.toLocaleLowerCase()
                ? "SALMON"
                : "TRANSPARENT",
          }}
        >
          {piece}
        </span>
      );
    });

  const handleSearch = (event) => {
    // console.log(data)
    const search = event.target.value;
    setSearchResult(search);
    if (search !== "") {
      const filterData = data.filter((item) => {
        // console.log(Object.values(item).join("").toLowerCase());
        return Object.values(item)
          .join("")
          .toLowerCase()
          .includes(search.toLowerCase());
      });

      // setFilterResult(filterData);
      setData(filterData);
    } else {
      // console.log("data" + data)
      fetchDatas(API)
      setData(data);
    }
  };

  const fetchDatas = async (url) => {
    try {
      // console.log(pagination);
      const res = await fetch(url);
      const responseJSON = await res.json();

      if (responseJSON.length > 0) {
        setData(responseJSON);
      }
      // console.log(responseJSON);
    } catch (e) {
      console.error(e);
    }
  };

  useEffect(() => {
    fetchDatas(API);
  }, []);

  const pages = [];
  for (let i = 1; i <= Math.ceil(data.length / itemsPerPage); i++) {
    pages.push(i);
  }

  const indexOfLastItem = currentPage * itemsPerPage;
  const indexOfFirstItem = indexOfLastItem - itemsPerPage;
  const currentItems = data.slice(indexOfFirstItem, indexOfLastItem);

  const renderPageNumbers = pages.map((number) => {
    if (number < maxPageNumberLimit + 1 && number > minPageNumberLimit) {
      return (
        <li
          onClick={handleClick}
          className={
            currentPage === number
              ? "active paginate_button page-item"
              : "paginate_button page-item"
          }
        >
          <a
            key={number}
            id={number}
            aria-controls="example"
            aria-disabled="true"
            aria-role="link"
            data-dt-idx="previous"
            tabIndex={0}
            className="page-link"
          >
            {number}
          </a>
        </li>
      );
    } else {
      return null;
    }
  });

  const handleNextbtn = () => {
    setcurrentPage(currentPage + 1);

    if (currentPage + 1 > maxPageNumberLimit) {
      setmaxPageNumberLimit(maxPageNumberLimit + pageNumberLimit);
      setminPageNumberLimit(minPageNumberLimit + pageNumberLimit);
    }
  };

  const handlePrevbtn = () => {
    setcurrentPage(currentPage - 1);

    if ((currentPage - 1) % pageNumberLimit === 0) {
      setmaxPageNumberLimit(maxPageNumberLimit - pageNumberLimit);
      setminPageNumberLimit(minPageNumberLimit - pageNumberLimit);
    }
  };

  let pageIncrementBtn = null;
  if (pages.length > maxPageNumberLimit) {
    pageIncrementBtn = (
      <li className="paginate_button page-item" onClick={handleNextbtn}>
        <a
          aria-controls="example"
          aria-disabled="true"
          aria-role="link"
          data-dt-idx="previous"
          tabIndex={0}
          className="page-link"
        >
          {" "}
          &hellip;{" "}
        </a>
      </li>
    );
  }

  let pageDecrementBtn = null;
  if (minPageNumberLimit >= 1) {
    pageDecrementBtn = (
      <li className="paginate_button page-item" onClick={handlePrevbtn}>
        <a
          aria-controls="example"
          aria-disabled="true"
          aria-role="link"
          data-dt-idx="previous"
          tabIndex={0}
          className="page-link"
        >
          {" "}
          &hellip;{" "}
        </a>
      </li>
    );
  }

  const handleLoadMore = () => {
    setitemsPerPage(itemsPerPage + 10);
  };

  return (
    <>
      {renderData(currentItems)}

      <div className="row">
        <div className="col-sm-12 col-md-5">
          {/* <div
            className="dataTables_info"
            id="example_info"
            role="status"
            aria-live="polite"
          >
            Showing 0 to 0 of 0 entries
          </div> */}
        </div>
        <div className="col-sm-12 col-md-7">
          <div
            className="dataTables_paginate paging_simple_numbers"
            id="example_paginate"
          >
            <ul className="pagination">
              <li
                className="paginate_button page-item previous"
                onClick={handlePrevbtn}
                disabled={currentPage === pages[0] ? true : false}
              >
                <a
                  aria-controls="example"
                  aria-disabled="true"
                  aria-role="link"
                  data-dt-idx="previous"
                  tabIndex={0}
                  className="page-link"
                >
                  Prev
                </a>
              </li>
              {pageDecrementBtn}
              {renderPageNumbers}
              {pageIncrementBtn}
              <li
                className="paginate_button page-item next"
                onClick={handleNextbtn}
                disabled={
                  currentPage === pages[pages.length - 1] ? true : false
                }
              >
                <a
                  aria-controls="example"
                  aria-disabled="true"
                  aria-role="link"
                  data-dt-idx="next"
                  tabIndex={0}
                  className="page-link"
                >
                  Next
                </a>
              </li>
              <li
                className="paginate_button page-item next"
                onClick={handleLoadMore}
              >
                <a
                  aria-controls="example"
                  aria-disabled="true"
                  aria-role="link"
                  data-dt-idx="next"
                  tabIndex={0}
                  className="page-link"
                >
                  Load More
                </a>
              </li>
            </ul>
          </div>
        </div>
      </div>
    </>
  );
};
