import React, { useState } from 'react'
import styles from "./header.module.css"
import { Link } from 'react-router-dom'

function Header() {

    const [open, setOpen] = useState(false)
    const [menu_class, setMenuClass] = useState(`${styles.menuBars} ${styles.unclicked}`)

    const handleChange = () => {
        if (!open) {
            setMenuClass(`${styles.menuBars} ${styles.clicked}`)
        }
        else {
            setMenuClass(`${styles.menuBars} ${styles.unclicked}`)
        }
        setOpen(!open)
    }

    return (
        <div className={styles.headerContainer}>
            <Link to='/' className={styles.heading}>
                Home
            </Link>
            <div className={styles.menuItem} onClick={handleChange}>
                <div className={menu_class}></div>
                <div className={menu_class}></div>
                <div className={menu_class}></div>
            </div>
            <div className={open ? `${styles.menuBar} ${styles.menuBarActive}` : `${styles.menuBar}`} onClick={handleChange}>
                <li>
                    <Link to='/drivers' className={styles.menuLinks}>Drivers</Link>
                </li>
                <li>
                    <Link to='/cars' className={styles.menuLinks}>Cars</Link>
                </li>
                <li>
                    <Link to='/travel-orders' className={styles.menuLinks}>Travel Orders</Link>
                </li>
            </div>
        </div>
    )
}

export default Header
