import format from 'date-fns/format';
import ptBR from 'date-fns/locale/pt-BR';

import styles from './styles.module.scss';

export function Header() {
    const currentDate = format(new Date(), 'EEEEEE, d MMMM', {
        locale: ptBR,
    });

    return (
        <header className={styles.headerContainer}>
            <img src="/mastersul-logo.png" alt="Mastersul" />

            <p>Desafio frontend e classes</p>

            <span>{currentDate}</span>
        </header>
    );
}