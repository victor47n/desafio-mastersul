import { useEffect, useState } from 'react';
import Head from 'next/head';
import { useRouter } from 'next/router'

import { api } from '../../services/api';

import styles from './user.module.scss';
import { PaymentModal } from '../../components/PaymentModal';
import Modal from 'react-modal';

Modal.setAppElement('#root');

type Payment = {
    id: number;
    type: string;
    value: number;
}

type Grid = {
    type: string;
    payments: Payment[];
}

export default function User() {
    const router = useRouter();
    const { slug } = router.query;

    const [isPaymentModalOpen, setIsPaymentModalOpen] = useState(false);
    const [payment, setPayment] = useState<Payment>({} as Payment);

    const [grids, setGrids] = useState<Grid[]>([])

    useEffect(() => {
        if (!slug) {
            return;
        }

        const fetchSomethingById = async () => {
            await api.get(`payments/1`)
                .then(response => setGrids(response.data))
        }

        fetchSomethingById()
    }, [slug])

    useEffect(() => {

    }, []);

    function handleOpenPaymentModal(payment: Payment) {
        setPayment({
            id: payment.id,
            type: payment.type,
            value: payment.value
        });

        setIsPaymentModalOpen(true);
    }

    function handleClosePaymentModal() {
        setIsPaymentModalOpen(false);
    }

    function removePayment(id: number) {
        try {
            const updatedGrids = [...grids];
            const gridIndex = updatedGrids.findIndex(grid => grid.payments.find(payment => payment.id === id));

            if (gridIndex >= 0) {
                updatedGrids[gridIndex].payments.splice(
                    updatedGrids[gridIndex].payments.findIndex(payment => payment.id === id),
                    1)

                setGrids(updatedGrids);
                handleClosePaymentModal();
            } else {
                throw Error();
            }

        } catch {
            alert('Erro na remoção da conta');
        }
    }

    return (
        <div className={styles.container}>
            <Head>
                <title>Teste | Desafio Mastersul</title>
            </Head>

            <div className={styles.grid}>
                {grids.map(grid => (
                    <div key={grid.type}>
                        <table cellSpacing={0}>
                            <thead>
                                <tr>
                                    <th>Tipo</th>
                                    <th>Valor</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                                {grid.payments.map(payment => (
                                    <tr key={payment.id}>
                                        <td>{payment.type}</td>
                                        <td>
                                            {new Intl.NumberFormat('pt-BR', {
                                                style: 'currency',
                                                currency: 'BRL'
                                            }).format(payment.value)}
                                        </td>
                                        <td>
                                            <button type="button" onClick={() => handleOpenPaymentModal(payment)}>
                                                <img src="/eye.svg" alt="Visualizar detalhes" />
                                            </button>
                                        </td>
                                    </tr>
                                ))}
                            </tbody>
                        </table>
                    </div>
                ))}
            </div>

            <PaymentModal
                isOpen={isPaymentModalOpen}
                onRequestClose={handleClosePaymentModal}
                payment={payment}
                onRemovePayment={removePayment}
            />
        </div>
    )
}